# DLL-Guvenlik-Analizi

**DLL Güvenlik Analizi ve İzleme Kiti** — Akademik ve savunma amaçlı açık kaynak proje.

**Önemli Uyarı:** Bu proje **sadece savunma, izleme, ve araştırma** amaçlıdır. İçerdiği kodlar saldırı, istismar veya atlatma teknikleri sağlamaz. Lütfen kodları yalnızca izole, test amaçlı ortamda (ör. VM snapshot alınmış) çalıştırın.

## İçerik
- `src/MemoryScanner/` — C# ile yazılmış, süreç bellek bölümlerini güvenli şekilde tarayan örnek.
- `src/ETWMonitor/` — Python ile ETW (Event Tracing for Windows) dinleyici örneği.
- `src/PowershellLogger/` — PowerShell ile basit modül yükleme izleyici.
- `docs/` — Mimari, kullanım kılavuzu, ve örnek çıktılar.
- `Thesis/` — Tez özeti ve doküman (Türkçe).
- `LICENSE` — MIT Lisansı.

## Hızlı Başlangıç
1. Projeyi izole bir VM'e kopyalayın (snapshot alın).
2. `src/MemoryScanner` dizinindeki C# kodlarını Visual Studio ile açıp derleyin.
3. Python ETW için `krabsetw` veya uygun ETW kütüphanesini izole VM'e kurun.
4. PowerShell script'ini yalnızca test VM'de yönetici olarak çalıştırın.

## Lisans
MIT — eğitim ve araştırma amaçlı kullanım. Detaylar `LICENSE` dosyasında.
