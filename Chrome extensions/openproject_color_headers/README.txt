UWAGI TECHNICZNE

Rozszerzenie działa tylko w przeglądarce Chrome.
Działa jedynie dla adresu *://10.0.0.101/openproject/my/page , gwiazdka (*) gwarantuje dowolność protokołu, po jakim się łączymy. Natomaiast jeśli będziemy używali DNSa zamiast adresu IP, kolorowanie NIE ZADZIAŁA.

INSTALACJA

1. W miejsce adresu URL wpisujemy chrome://extensions
2. Włączamy tryb dewelopera w prawym górnym rogu
3. W lewym górnym rogu powinny się pojawić przyciski, spośród których wciskamy "Załaduj rozpakowane" (w wersji angielskiej "Load unpacked").
4. W okienku wyboru wybieramy katalog z rozszerzeniem.
5. Wyłączamy tryb dewelopera i cieszymy się rozszerzeniem.

POZOSTAŁE UWAGI

Ze względu na to, że we frontendzie jest wykorzystana asynchroniczność podczas ładowania raportów, ciężko znaleźć zdarzenie przeglądarki lub dokumentu (strony), które gwarantowało by nam to, że już mamy wczytany cały widok tygodni. Zatem założono, że widok ten wczyta się do 10 sekund po załadowaniu strony. Jeśli to założenie nie zostanie spełnione, aby pokolorować nagłówki, należy odświeżyć stronę (wtedy zostanie ona załadowana z pamięci podręcznej, a więc założenie będzie spełnione, a nagłówki pokolorowane).