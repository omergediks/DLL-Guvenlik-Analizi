# DLL Güvenlik Analizi ve Yürütme İzleme Aracı

Bu proje, Windows ortamlarında **DLL yükleme süreçlerini**, **bellek bölgelerini**, **ETW (Event Tracing for Windows)** olaylarını ve **kernel seviyesinde oluşan davranışları** izleyerek şeffaf bir güvenlik görünürlüğü sağlamayı amaçlayan çok katmanlı bir analiz aracıdır.

Amaç; kullanıcı modundaki işlemlerin dinamik davranışlarını, şüpheli DLL yüklemelerini, bellek izin değişikliklerini ve ETW üzerinden aktarılan düşük seviye olayları gözlemleyebilmektir.

Proje; C#, PowerShell ve Python ile yazılmış çok bileşenli bir yapıya sahiptir ve laboratuvar/test ortamlarında yürütme analizi, davranış modelleme ve güvenlik telemetri toplama amacıyla tasarlanmıştır.

---

## 🚀 Özellikler

- **DLL yükleme ve çağrılarının gerçek zamanlı takibi**
- **RWX (Read/Write/Execute) bellek bölgelerinin tespiti**
- **ETW üzerinden Userland → Kernel ilişkisinin izlenmesi**
- **PowerShell ile kernel event’lerinin çekilmesi**
- **Python ETW listener ile komut tabanlı izleme altyapısı**
- **Yüksek seviye log formatı (JSON/PlainText)**
- **Modüler, genişletilebilir mimari**
- **Tamamen kullanıcı modunda çalışan izleyici + PowerShell kernel mod event abstreksiyonu**
- **Sanal makine / test ortamı odaklı kullanım**

---

## 📂 Proje Yapısı

DLL-Guvenlik-Analizi/
│
├── CSharp/
│ ├── DllLoadListener.cs # DLL yüklemelerini tespit eden .NET listener
│ ├── MemoryMonitor.cs # Bellek bölgelerini tarayan analizci
│
├── Python/
│ ├── etw_listener.py # ETW event toplayıcı (Userland ETW consumer)
│
├── PowerShell/
│ ├── kernel_logger.ps1 # Kernel event kanalından telemetry toplayıcı
│
├── Thesis.md # Teknik açıklamalar ve mimari
├── Thesis.pdf # Çalışmanın PDF çıktısı
├── LICENSE
├── CONTRIBUTING.md
└── README.md

markdown
Kodu kopyala

---

## 🧩 Mimari Genel Bakış

Proje üç farklı katmanda çalışır:

### **1) Kullanıcı Modu: DLL ve Bellek İzleme (C#)**

- `DllLoadListener.cs` →  
  Windows API üzerinden proses içi **DLL yükleme olaylarını (LoadLibraryW, LdrLoadDll)** izler.  
  Modül adı, load adresi ve işlem ID’sini loglar.

- `MemoryMonitor.cs` →  
  `VirtualQueryEx` çağrılarıyla bellek bölgelerini tarar ve özellikle:
  - `PAGE_EXECUTE_READWRITE`
  - `PAGE_EXECUTE_WRITECOPY`
  gibi şüpheli izin kombinasyonlarını raporlar.

### **2) ETW Dinleyici (Python)**

- `etw_listener.py` →  
  Microsoft’un ETW altyapısı üzerinden aşağıdaki sağlayıcıları tüketebilir:
  - `Microsoft-Windows-Kernel-Process`
  - `Microsoft-Windows-Kernel-Image`
  - `Microsoft-Windows-Threat-Intelligence`

Bu katman, proses oluşturma, imgage load, thread başlangıçları ve diğer düşük seviye event’leri işler.

### **3) PowerShell Kernel Logger**

- `kernel_logger.ps1` →  
  Kernel event kanalına bağlanır ve sistemde gerçekleşen:
  - Image load
  - Thread scheduling
  - Memory map değişiklikleri
  - Handle açma olayları
  gibi davranışları toplayıp JSON formatında dışarı aktarır.

---

## 📊 Üretilen Telemetri

Sistem aşağıdaki türde loglar üretir:

### **DLL Logları**
```json
{
  "timestamp": "2025-01-02T14:05:22Z",
  "process": "chrome.exe",
  "pid": 4400,
  "dll": "user32.dll",
  "base": "0x7FFBF12A0000"
}

````
## Bellek Analizi


{
  "pid": 928,
  "region_start": "0x0000012340000000",
  "size": 4096,
  "protection": "PAGE_EXECUTE_READWRITE"
}
ETW Eventleri

{
  "event": "ImageLoad",
  "process": "explorer.exe",
  "path": "\\Device\\HarddiskVolume3\\Windows\\System32\\kernel32.dll"
}

'''
⚙️ Kurulum
1. Repo’yu klonla

git clone https://github.com/omergediks/DLL-Guvenlik-Analizi.git
2. C# projelerini build et
Visual Studio veya dotnet CLI kullanılabilir.


3. Python bağımlılıkları

pip install etw
4. PowerShell scripti


powershell -ExecutionPolicy Bypass -File .\PowerShell\kernel_logger.ps1
📘 Kullanım
DLL ve Bellek İzleme

DllLoadListener.exe
MemoryMonitor.exe
ETW Listener
bash
Kodu kopyala
python etw_listener.py
Kernel Logger

.\kernel_logger.ps1
Tüm loglar logs/ dizinine düşer.

🔧 Genişletilebilirlik
Proje kolayca geliştirilebilir:

Yeni ETW provider ekleme

Ek bellek imza kontrolü

Proses içi hooking mekanizması ekleme

Log normalizasyonu + veritabanı entegrasyonu

Görsel dashboard (Grafana/Elastic/Kibana)

🛠 Geliştirici Notları
Kodlar tamamen test ortamı kullanımına uygundur.

Windows 10/11 + .NET 6 + Python 3.10 ile test edildi.

ETW yetkilendirmesi için yönetici hakları gerekebilir.

📄 Lisans
Bu proje MIT lisansı ile yayınlanmıştır.

⭐ Destek Olmak İçin
Projeyi faydalı bulduysan yıldız verebilirsin!

