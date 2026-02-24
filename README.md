Funkciju apraksts
Collectibles

Spēles laikā periodiski tiek ģenerēti savācami objekti noteiktās pozīcijās (spawn punktos).

Kad jebkurš zombijs saskaras ar collectible objektu:

tiek izsaukta savākšanas funkcija,

objekts tiek iznīcināts (Destroy),

spēlētājam tiek piešķirti punkti.

Objekti izmanto Collider ar ieslēgtu Is Trigger, lai noteiktu sadursmi bez fiziskas atgrūšanās.

Score sistēma

Kad zombijs savāc objektu:

tiek izsaukta metode CollectItem(int amount),

punktu skaits tiek palielināts,

UI teksta elements tiek atjaunināts.

Punkti tiek attēloti UI slānī ekrāna stūrī, izmantojot TextMeshPro komponenti.
Rezultāts tiek dinamiski atjaunināts spēles laikā.

Timer

Spēlei sākoties:

taimeris sāk skaitīt laiku no 0 sekundēm,

laiks tiek palielināts katrā kadrā, izmantojot Time.deltaTime.

Taimeris:

tiek parādīts UI slānī,

tiek formatēts sekundēs ar vienu ciparu aiz komata,

apstājas, kad spēle beidzas (Lose state).

Lose State

Ja jebkurš zombijs nokrīt zem noteiktās Y koordinātas vai iekļūst DeathZone zonā:

tiek aktivizēts GameOver() stāvoklis,

taimeris apstājas (Time.timeScale = 0 vai apturēta atjaunošana),

parādās teksts "You lose",

parādās restartēšanas poga.

Nospiežot restart pogu:

spēle tiek ielādēta no jauna,

taimeris sākas no 0,

punkti tiek atiestatīti.

Papildus punkti (paplašinājumi)
Skaņas efekti (savākšanas skaņa, zaudējuma skaņa)
