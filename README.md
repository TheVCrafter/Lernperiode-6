# Lern-Periode 6

22.8 bis 19.9.2024

## Grob-Planung

Ich habe mich für diese Lernperiode für eine eigene Projektidee entschieden. Dabei habe ich auch persönliche Aspekte in meine Spielidee einfliessen lassen ("Kaffee-Sucht").
Ich möchte ein einfaches aber funktionales Racing Game namens "caffeine Racer" entwickeln. Bei dem Spiel geht es darum nach dem start während einer begrenzten zeit an möglichst vielen gegnerischen Autos vorbei zu manövrieren. Dabei hat der Fahrer ein Müdigkeitslevel. Je müder der Fahrer wird, desto langsamer wird das Auto und wenn der Fahrer einschläft baut man einen Unfall und es ist Game-Over. Um so ein Szenario zu verhindern, muss man während dem Fahren Kaffeebohnen einsammeln um den Fahrer wieder wacher zu machen.
Zusammengefasst handelt es sich also um ein unterhaltsames Rennspiel mit einem speziellen Twist.

## 22.8

- [X] Arbeitspaket 1: Erstellen Sie ein Projekt im VS und beginnen Sie mir ersten Code-Skizzen. Das ist wichtig, Sie müssen heute bereits schon C#-Code hochladen!
- [ ] Arbeitspaket 2: Schreiben Sie eine Liste, welche Klassen und Objekte es braucht, und wie diese miteinander interagieren. Das Format ist Ihnen freigestellt, aber Sie müssen es auch bereits heute auf github laden.

Heute habe ich mir zunächst überlegt, was ich in dieser Lernperiode Programmieren könnte. Schon bald kam ich auf die Idee, ein Rennspiel zu entwickeln. Anschliessend begann ich bereits etwas darüber nachzudenken, wie ich den Code strukturieren sollte, also welche Klassen das Spiel benötigt und begann auch bereits damit diese Struktur im VS zu implementieren. Mit dem Implementieren eines funktionalen Aspektes konnte ich leider aus Zeitgründen nicht mehr beginnen.

## 29.8

- [X] Struktur: Offline weiter darüber Nachdenken welche Klassen noch benötigt werden und anschliessend mit der Festlegung der Klasseninternen Struktur beginnen
- [ ] Painter: Beginn der grundlegenden Implementation der Painter-Klasse (Draw-Funktion). Ausführliches Testen mit verschiedensten Formen, Bugs finden und beheben
- [ ] DRY-Prinzip: Redundante Stellen finden und in Methoden/Funktionen auslagern

Heute habe ich grösstenteils an der Code-Strukur des Spiels gearbeitet. Zunächst habe ich gut eine Stunde offline nochmals darüber nachgedacht welche weiteren Klassen noch benötigt werden und welche Funktionen und Eigenschaften diese dann jeweils erhalten. Ausserdem habe ich versucht die bereits bestehenden Klassen noch weiter zu verbessern. Ich habe sie also teilweise umbenannt und auch die Funktionalitäten überarbeitet. Dann begann ich damit die verbesserte Struktur in mein Projekt zu übernehmen und codierte auch bereits die Grundfunktion des Timers. Für weiteres reichte es mir Zeitlich leider nicht aber ich bin allgemein sehr zufrieden mit dem fortschritt den ich machen konnte.

<img height="525" alt="Struktur1" src="struktur1.jpeg"/>
<img height="525" alt="Struktur2" src="struktur2.jpeg"/>

## 5.9

- [X] Programmablauf: Erarbeiten eines sinnvollen und übersichtlichen Programmablaufplans um das Implementieren zu erleichtern (Offline)
- [X] Renderer: Implementation eines sinnvollen Gamerenderers um das grafische Geschehen korrekt anzuzeigen (Siehe Painter vom 29.8). Ausführlich Testen und falls möglich versuchen damit ein bestandteil des Spiels (Auto, Rennbahn. Kaffebohne etc.) anzuzeigen.
- [ ] Implementation der benötigten Logik in der Klasse `Game.cs` nach Programmablaufplan
- [ ] DRY-Prinzip: Den neuen code auf Redundanzen überprüfen und diese zusammenfassen (siehe DRY-Prinzip 29.8)

Heute habe ich grösstenteils an dem Rendering gearbeitet. Zunächst hatte ich das Problem, dass ich durch die Limitation der Konsolen Farben etwas eingeschränkt wurde. Ich stellte also etwas Recherche an und fand heraus, dass man alle RGB-Farben mithilfe von ANSI Sequences für Fore- und Backgroundcolor setzen kann. Das Ganze seht im Code so aus: 

**ForegroundColor**:`\u001b[38;2;{r};{g};{b}m`

**BackgroundColor**:`\u001b[48;2;{r};{g};{b}m`

Den Renderer implementierte ich, indem ich für jede Position in der Konsole, den Farbcode für die jeweilige Farbe in einem 2D-Array speicherte. In dem ich einen Speziellen Char verwendete (▀), konnte ich pro Position jeweils 2 Pixel painten (einen mit Foreground Color und einen mit Background Color) und so die Auflösung noch weiter erhöhen. Ich testete das Ganze zunächst mit einfachen Formen (Rechtecke/Quadrate) und begann anschliessend auf der Website [Pixilart](https://www.pixilart.com) bereits damit, eine Kaffebohne zu designen.

![KaffeeBohne](CoffeeBean.png)

Als ich damit fertig war, schrieb ich noch den Benötigten Code um die Kaffebohne in der Konsole anzuzeigen.
```csharp
        public void DrawCoffeeBean(int x, int y)
        {
            /*  Farbpalette:
                "\u001b[48;2;0;0;0m";
                "\u001b[48;2;72;45;20m";
                "\u001b[48;2;117;77;41m";
                "\u001b[48;2;49;28;12m";
                -> for ForegroundColor 38 instead of 48
            */

            //Zeile 1
            _screen[x,y]+= "\u001b[48;2;72;45;20m";
            _screen[x+1,y]= "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            _screen[x+2,y]= "\u001b[48;2;117;77;41m\u001b[38;2;72;45;20m";
            _screen[x+3,y]= "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            _screen[x+4,y]+= "\u001b[48;2;72;45;20m";

            //Zeile 2
            _screen[x,y+1] = "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            _screen[x+1,y+1] = "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            _screen[x+2, y+1] = "\u001b[48;2;49;28;12m\u001b[38;2;117;77;41m";
            _screen[x+3,y+1] = "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            _screen[x+4,y+1] = "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            
            //Zeile 3
            _screen[x, y+2] = "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            _screen[x+1,y+2]= "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            _screen[x + 2, y + 2] = "\u001b[48;2;49;28;12m\u001b[38;2;49;28;12m";
            _screen[x + 3, y + 2] = "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            _screen[x + 4, y + 2] = "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            //Zeile 4
            _screen[x, y + 3] += "\u001b[38;2;72;45;20m";
            _screen[x + 1, y + 3] = "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            _screen[x+ 2, y + 3] = "\u001b[48;2;72;45;20m\u001b[38;2;117;77;41m";
            _screen[x+3,y+3] = "\u001b[48;2;72;45;20m\u001b[38;2;72;45;20m";
            _screen[x+4, y + 3] += "\u001b[38;2;72;45;20m";
        }
```
In der Konsole:

![CoffeeBeanConsole](CoffeeBeanInConsole.png)
Ansonsten arbeitete ich auch noch offline daran, einen grundlegenden Programmablauf für mein Programm zu zeichnen.

<img height="525" alt="Programmablauf1" src="Programmablauf1.jpeg"/>
<img height="525" alt="Programmablauf2" src="Programmablauf2.jpeg"/>

## 12.09.

- [X] **Rendering:** Autos und Rennbahn anzeigen. Zunächst Grafiken auf Pixilart.com erstellen, anschließend in der `Rendering`-Klasse implementieren.
- [ ] **Spielerauto-Steuerung:** Spielerauto mit den Tasten `A` (links) und `D` (rechts) bewegen. Dazu Methode zur Tastenerkennung implementieren.  
- [X] **Bewegung der Spielwelt:** Bewegung simulieren, indem alle Elemente außer dem Spielerauto nach unten verschoben werden.  
- [ ] **Kollisionserkennung:** Kollisionen zwischen Spielerauto, Gegnerautos und Kaffeebohnen erkennen und entsprechend reagieren.  

Heute habe ich zunächst passende Designs für Rennbahn, Autos und die Kaffeebohne auf Pixilart.com erstellt. Anschliessend habe ich die Grafiken in die `Renderer`-Class implementiert und ausgiebig daran gearbeitet, die Rennbahn zu animieren, um die Bewegung der Spielwelt darzustellen. Dabei traten einige Fehler auf, zum Beispiel dass sich bestimmte Curbs nicht korrekt verschoben und die Scrollrichtung manchmal nicht stimmte. Aus Zeitgründen konnte ich diese Probleme leider nicht mehr vollständig beheben.

Der bisherige Code in der `Renderer`-Class zum rendern der Kaffebohne und der Track (mit animation):
```csharp
 public void DrawTrack(int offset)
 {
     string ColorWhite = "\u001b[48;2;255;255;255m\u001b[38;2;255;255;255m";
     string ColorRed = "\u001b[48;2;255;0;0m\u001b[38;2;255;0;0m";
     string trackColor = "\u001b[48;2;70;70;70m\u001b[38;2;70;70;70m";

     for (int i = 0; i < Height; i++)
     {
         string curbColor = ((i / 2) % 2 == 0) ? ColorWhite : ColorRed;
         int yPos = (i + offset) % Height;
         for (int b = 0; b < 3; b++)
         {
             _screen[10 + b, yPos] = curbColor;
             _screen[Width - 11 - b, yPos] = curbColor;
         }

         for (int j = 13; j < Width - 13; j++)
         {
             _screen[j, yPos] = trackColor;
         }
     }
 }


 public void DrawCoffeeBean(int x, int y)
 {
     // Mittelbraun (rgba(99,51,15,255))
     string foreBrownMedium = "\u001b[38;2;99;51;15m";
     string backBrownMedium = "\u001b[48;2;99;51;15m";

     // Hellbraun (rgba(141,68,17,255))
     string foreBrownLight = "\u001b[38;2;141;68;17m";
     string backBrownLight = "\u001b[48;2;141;68;17m";  

     // Dunkelbraun (rgba(64,30,5,255))
     string foreBrownDark = "\u001b[38;2;64;30;5m";
     string backBrownDark = "\u001b[48;2;64;30;5m";

     //Bean
     _screen[x, y] += foreBrownMedium;
     _screen[x + 1, y] += foreBrownMedium;
     if (y>0)
     {
         _screen[x-1, y - 1] = backBrownLight + foreBrownLight;
         _screen[x, y-1] = backBrownMedium + foreBrownLight;
         _screen[x + 1, y - 1] = backBrownDark + foreBrownDark;
         _screen[x + 2, y-1] = backBrownMedium + foreBrownMedium;
     }
     if (y > 1)
     {
         _screen[x - 1, y - 2] += backBrownLight;
         _screen[x, y - 2] = backBrownDark + foreBrownLight;
         _screen[x + 1, y - 2] = backBrownMedium + foreBrownLight;
         _screen[x + 2, y - 2] += backBrownMedium;
     }
 }
```
Ausgabe in der Konsole:

<img width="1115" height="628" alt="Screenshot 2025-09-12 102840" src="https://github.com/user-attachments/assets/30b5b23c-de0c-4c87-aa4b-c3a8f723c2e0" />


Die Designs von "RSR Pixel Art welche ich für mein Spiel verwenden möchte:

<img width="233" height="525" alt="Car1" src="Car1.png"/> <img width="233" height="525" alt="Car2" src="Car2.png"/> <img width="233" height="525" alt="Car3" src="Car3.png"/>

# 17.10.

- [X] **Autos:** Verschiedene Autos in der `DrawCar`-Methode der `Renderer`-Klasse implementieren, nach dem gleichen Prinzip wie die Kaffeebohne und die Rennbahn.  
- [X] **Spielerauto-Steuerung:** Spielerauto mit den Tasten `A` (links) und `D` (rechts) bewegen; Methode zur Tastenerkennung implementieren.  
- [ ] **Kollisionserkennung:** Kollisionen zwischen Spielerauto, Gegnerautos und Kaffeebohnen erkennen und entsprechend reagieren.  
- [ ] **Müdigkeitslevel:** Geschwindigkeit des Spielerautos abhängig von Müdigkeit anpassen; Kaffeebohnen-Konsum erhöht Geschwindigkeit; einfache Anzeige des aktuellen Müdigkeitslevels implementieren.

Heute habe ich mich vor allem auf die Optimierung meines Renderers konzentriert und die bisherigen Fortschritte am Spiel weiter ausgebaut. Ich habe Multithreading implementiert, den 2-Pixel-Support mit Foreground- und Background-Farben vollständig ausgebaut und verschiedene Bugs beim Scrollen der Strecke behoben, die zuletzt noch auftraten, wie falsche Verschiebungen bestimmter Curbs oder ungenaue Scrollrichtungen. Zudem habe ich die bisherigen Arbeiten an den Autos weitergeführt und zunächst das Spielerauto gepixelt. Die Steuerung des Spielerautos mit den Tasten A und D funktioniert nun zuverlässig, inklusive stabiler Tastenerkennung. Es gibt jedoch noch einen Bug: Das Spielerauto wird aktuell nur halb angezeigt.

Die Aktuelle Ausgabe in der Konsole:
<img width="233" height="525" alt="Car1" src="Rendering.gif"/>

Ein wichtiger Schritt war die Überarbeitung der Renderer-Klasse: Ich habe ein Farben-Dictionary erstellt, um die wichtigsten Farben zentral zu speichern, was das "Pixeln" von Spielelementen erheblich erleichtert und den Code übersichtlicher macht. Das Rendering erfolgt nun nicht mehr direkt im Renderer, sondern in der `Render()`-Methode der jeweiligen Klasse, wodurch die Code-Struktur deutlich sauberer und wartungsfreundlicher geworden ist. Der Renderer unterstützt jetzt auch den 2-Pixel-pro-Zeile-Modus, was die Darstellung der Spielwelt verbessert.
Das in der `Renderer`-Class erstellte Dictionary:
```C#
Colors = new Dictionary<string, string>()
{
    // Environment
    { "GRASS_DARK", "2;0;100;0m" },
    { "GRASS_MEDIUM", "2;0;150;0m" },
    { "GRASS_LIGHT", "2;0;200;0m" },
    { "ASPHALT_DARK", "2;50;50;50m" },
    { "ASPHALT_MEDIUM", "2;100;100;100m" },
    { "ASPHALT_LIGHT", "2;150;150;150m" },

    // Track Curbs
    { "CURB_RED", "2;255;0;0m" },
    { "CURB_YELLOW", "2;255;215;0m" },
    { "CURB_WHITE", "2;255;255;255m" },

    // Coffee Beans
    { "COFFEE_LIGHT", "2;141;68;17m" },
    { "COFFEE_MEDIUM", "2;99;51;15m" },
    { "COFFEE_DARK", "2;64;30;5m" },

    // General colors
    { "BLACK", "2;0;0;0m" },
    { "WHITE", "2;255;255;255m" },

    // Ferrari
    { "FERRARI_DARK_RED", "2;130;23;41m" },
    { "FERRARI_RED", "2;232;0;45m" },
    { "FERRARI_LIGHT_RED", "2;255;76;106m" },
    { "FERRARI_YELLOW", "2;255;221;0m" },
    { "FERRARI_WHITE", "2;255;255;255m" },

    // Mercedes
    { "MERCEDES_DARK_GRAY", "2;60;60;60m" },
    { "MERCEDES_GRAY", "2;128;128;128m" },
    { "MERCEDES_LIGHT_GRAY", "2;192;192;192m" },
    { "MERCEDES_TURQUOISE", "2;0;215;182m" },

    // Red Bull Racing
    { "RED_BULL_RED", "2;218;41;28m" },
    { "RED_BULL_DARK_BLUE", "2;0;0;139m" },
    { "RED_BULL_BLUE", "2;71;129;215m" },
    { "RED_BULL_LIGHT_BLUE", "2;173;216;230m" },
    { "RED_BULL_YELLOW", "2;255;215;0m" },

    // McLaren
    { "MCLAREN_ORANGE", "2;255;128;0m" },
    { "MCLAREN_WHITE", "2;255;255;255m" },

    // Alpine
    { "ALPINE_BLUE", "2;0;161;232m" },
    { "ALPINE_RED", "2;255;0;0m" },
    { "ALPINE_WHITE", "2;255;255;255m" },

    // Aston Martin
    { "ASTON_MARTIN_GREEN", "2;34;153;113m" },
    { "ASTON_MARTIN_WHITE", "2;255;255;255m" },

    // Williams
    { "WILLIAMS_BLUE", "2;24;104;219m" },
    { "WILLIAMS_WHITE", "2;255;255;255m" },

    // Alfa Romeo
    { "ALFA_ROMEO_RED", "2;186;0;0m" },
    { "ALFA_ROMEO_WHITE", "2;255;255;255m" },

    // Haas
    { "HAAS_RED", "2;186;0;0m" },
    { "HAAS_WHITE", "2;255;255;255m" },

    // AlphaTauri
    { "ALPHATAURI_BLUE", "2;0;0;255m" },
    { "ALPHATAURI_WHITE", "2;255;255;255m" }
};
```
PS: Da ich mit dem Projekt noch nicht ganz fertig bin und ich ausserdem Krankheitsbedingt am 19.09.2025 daran nicht arbeiten konnte, habe ich mir vorgenommen, das Projekt innerhalb der nächsten Woche komplett abzuschliessen.

## 17.10 - 24.10
- [ ] **Player-Car-Bug beheben:** Spielerauto wird aktuell nur halb angezeigt; Höhe und 2-Pixel-Pro-Zeile-Modus prüfen und korrigieren.  
- [ ] **Kollisionserkennung:** Kollisionen zwischen Spielerauto, Gegnerautos und Kaffeebohnen erkennen und entsprechend reagieren.  
- [ ] **Weitere Autos:** Mindestens ein weiteres Gegnerauto designen, pixeln und in die `DrawCar`-Methode der `Renderer`-Klasse implementieren.  
- [ ] **Performance testen:** Den aktuellen Renderer mit Multithreading und 2-Pixel-Support auf mögliche Performance-Probleme prüfen und ggf. optimieren.  
- [ ] **Müdigkeitslevel implementieren:** Geschwindigkeit des Spielerautos abhängig von Müdigkeit anpassen; Kaffeebohnen-Konsum erhöht Geschwindigkeit; Anzeige des aktuellen Levels integrieren.  
- [ ] **Gegnerautos-Bewegung:** Gegnerautos auf der Rennbahn bewegen und Kollisionsmöglichkeiten mit Spielerauto berücksichtigen.  
- [ ] **Punkte- und Sammelsystem:** Punkte für eingesammelte Kaffeebohnen oder überholte Gegnerautos einführen und in der UI anzeigen.  
- [ ] **Menü & Startbildschirm:** Einfaches Startmenü mit Spielstart, evtl. Spielende-Bildschirm und Neustart-Option implementieren.  
- [ ] **Soundeffekte / Feedback:** Einfache Audio- oder visuelle Effekte für Kollisionen, Punkte und Geschwindigkeitsänderungen hinzufügen.  
- [ ] **Endtest & Bugfixing:** Das gesamte Spiel durchtesten, alle Bugs beheben und sicherstellen, dass alles stabil läuft.
- [ ] **Reflexion schreiben:** Eigene Erfahrungen, Herausforderungen und Learnings aus dem Projekt zusammenfassen.
