// See https://aka.ms/new-console-template for more information

using PracaDomowa_1_s30679;

Kontener_na_plyny kon1 = new Kontener_na_plyny(1,1,1,1,1,true);
kon1.oproznianie_ladunku();
Console.WriteLine(kon1.Get_masa_ladunku_kg);