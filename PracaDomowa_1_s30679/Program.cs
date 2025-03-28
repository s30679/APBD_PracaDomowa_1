// See https://aka.ms/new-console-template for more information

using PracaDomowa_1_s30679;

Kontener_na_plyny kon1 = new Kontener_na_plyny("nazwa",1,1,1,1,3,true);
kon1.oproznianie_ladunku();
Kontenerowiec k1 = new Kontenerowiec(2,3,4);
Kontener_na_gaz g1 = new Kontener_na_gaz("Azot", 3, 3, 3, 3, 3, 33);
Kontenerowiec k2 = new Kontenerowiec(2,3,4);
Kontenerowiec k3 = new Kontenerowiec(100,300,100);

k1.ZaladujLadunekKontener(kon1,1);

k1.ZaladowanieKonteneraNaStatek(kon1);

k1.Wypisanie_informacji_o_danym_statku(k1);

Console.WriteLine(kon1.Get_masa_ladunku_kg);

k2.ZaladowanieKonteneraNaStatek(g1);

k2.przeniesKontener(g1,k3);

