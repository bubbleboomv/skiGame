Izpildītie uzdevumi:

1. Līmeņa izveide – Izveidots slēpošanas līmenis ar slīpumu, šķēršļiem, kokiem un fona elementiem

2. Spēlētāja kontrole – PlayerControll.cs – spēlētājs griežas pa kreisi/labi, virzās uz priekšu balstoties uz leņķi, Linecast zemes pārbaude

3. Sadursmes ar šķēršļiem – Obstacle.cs – akmens šķērslis reģistrē sadursmi ar spēlētāju un raksta konsolē. ObstacleDestroy.cs – sniegavīrs pazūd pēc sadursmes

4. Atmešana atpakaļ – PlayerControll.cs – pēc sadursmes spēlētājam tiek pievienots atsitiena spēks un kontrole tiek atspējota uz 1 sekundi

5. Sacensību loģika – StartGate.cs, FinishGate.cs, GateObstacle.cs, GameManager.cs – sacensības sākas pie starta karodziņa, zilajiem jābrauc pa labi, rozā pa kreisi, nepareiza puse = +1 sekunde sods, laiks apstājas pie finiša

6. Spēles beigu ekrāns – EndScreen.cs – parāda kopējo laiku, pogas Restart/Next Level/Quit

7. Datu saglabāšana un līderu saraksts – Leaderboard.cs – top 5 laiki saglabāti izmantojot PlayerPrefs, saglabājas starp sesijām

8. Līderu saraksta vizualizācija – Scroll View ar 5 ierakstiem beigu ekrānā, parāda labākos laikus MM:SS formātā. Pievienots custom sprite Canvas fonam un pogām

9. Skaņas – AudioManager.cs – sadursmes skaņa tiek atskaņota katru reizi kad spēlētājs trāpa šķērslim
