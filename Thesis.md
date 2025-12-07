
# Dinamik Davranışsal Analiz ile DLL Yükleme Anomalilerinin Tespiti ve Güvenlik Mimarisinin Tasarımı

## Özet
Modern işletim sistemlerinde dinamik bağlantı kitaplıkları (DLL) hem yazılım modülerliği hem de esneklik sağlar. Ancak kötü amaçlı aktörler de aynı mekanizmayı süreçlere izinsiz kod yüklemek ve yürütmek için kullanmaktadır. Bu çalışma, DLL yükleme davranışlarını izleyen, anomalileri tespit eden ve olay sonrası veriyi toplayan bir savunma mimarisi önerir. Tasarım, çekirdek ve kullanıcı modu telemetri entegrasyonu, bellek izin davranışı analizi, ve davranışsal risk skorlama içerir.

## 1. Giriş
... (The full thesis content continues with detailed sections)
## 1. Giriş

Bu çalışmanın amacı; DLL yükleme anomalilerini tespit etmek ve güvenlik analiz mimarisi tasarlamaktır.


## 2. Teorik Arka Plan

Bu bölümde DLL injection teknikleri (CreateRemoteThread, Reflective Injection, APC, Process Hollowing) teorik olarak incelenir. Her tekniğin davranış profili ve tespit göstergeleri tartışılır.


## 3. Mimari Tasarım

Proposed Architecture: Behavior Engine, Process & Memory Monitor, DLL Anomaly Engine, Kernel Syscall Trace, Sandbox & Evidence Collector.


### 3.1 Behavior Engine

Behavior Engine, API zincirlerini, permission değişikliklerini ve process lifecycle'ı korelasyon ile analiz eder.


### 3.2 Process & Memory Monitor

Memory map snapshot'ları, VAD değişiklikleri, RWX bölge tespiti, handle izinleri izlenir.


### 3.3 DLL Anomaly Engine

Yüklenen DLL'lerin imza ve hash doğrulaması, path kontrolü, in-memory only yükleme detektörleri tartışılır.


## 4. Uygulama Örnekleri

Bu bölümde örnek izleme kodları (memory scan, ETW listener) verilmiştir. Bu kodlar yalnızca veri toplama ve analiz amaçlıdır.


## 5. Deneysel Tasarım

İzole bir VM üzerinde test senaryoları tanımlanır; benign ve malicious-benzeri yükleme dizileri karşılaştırılır.


## 6. Değerlendirme

Risk skorlarının doğruluğu, false positive/negative analizi, performans yükü değerlendirilir.


## 7. Sonuç

Mimari, DLL tabanlı bellek manipülasyonlarını tespit etmeye yardımcı olur ve olay sonrası adli veriyi güvenli biçimde toplayabilir.


## Kaynaklar

[1] Microsoft ETW documentation
[2] Windows Internals

