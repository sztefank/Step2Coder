#include <iostream>
#include <string>
#include <map>

using namespace std;

int choice;
string name;
int note;
string warning = "Bitte geben sie zuerst einen Studenten an.";
map<string, int> name_note;
int counter = 1;

int main()
{
    do 
    {
        cout << "\n1 Um den Namen & die Note eines Studenten anzugeben.\n" <<
                "2 Um einen Studenten & seine Note auszulesen.\n" <<
                "3 Um Alle Studenten & ihre Noten auszulesen.\n" <<
                "4 Um einen Studenten zu entfernen.\n" <<
                "5 Um den Wert an einer bestimmten Stelle anzuzeigen.\n" <<
                "6 Um das Programm zu beenden.\n" << endl;

        cin >> choice;

        switch (choice) 
        {
        case 1:
            cout << "Geben sie bitten zuerst den Namen ein und dann die Note:" << endl;

            cin >> name;
            cin >> note;

            if (note < 1 || note > 5) 
            {
                cout << "Bitte geben sie eine valide note an" << endl;
            }
            else 
            {
                name_note[name] = note;
            }

            break;
        case 2:

            if (name_note.size() != 0) 
            {

                cout << "Geben sie den Namen der Studenten an dessen Note sie auslesen wollen:" << endl;
                cin >> name;

                for (auto n : name_note) 
                {
                    if (n.first == name) 
                    {
                        cout << n.first << ":" << n.second << endl;
                    }
                }
            }
            else 
            {
                cout << warning << endl;
            }

            break;
        case 3:

            if (name_note.size() != 0) 
            {
                for (auto n : name_note)
                {
                    cout << n.first << ":" << n.second << endl;
                }
            }
            else 
            {
                cout << warning << endl;
            }

            break;
        case 4:

            if (name_note.size() != 0) 
            {
                cout << "Geben sie den Namen des Studenten an der entfernt werden soll:" << endl;
                cin >> name;

                if (name_note.find(name) != name_note.end())
                {
                    name_note.erase(name);
                }
                
                cout << "Der Student " << name << " wurde entfernt." << endl;
            }
            else 
            {
                cout << warning << endl;
            }

            break;
        case 5:

            if (name_note.size() != 0)
            {

                cout << "Geben sie die Stelle ein die sie auslesen wollen: " << endl;

                cin >> choice;

                if (choice <= name_note.size())
                {
                    for (auto n : name_note)
                    {
                        if (counter == choice) 
                        {
                            cout << "Der Student an Stelle " << choice << " ist " << n.first << ": " << n.second;
                        }
                        counter += 1;
                    }
                    counter = 1;
                }
                else
                {
                    cout << "Es sind nicht genug Studenten" << endl;
                }
            }
            else
            {
                cout << warning << endl;
            }

            break;
        case 6:
            cout << "Programm wird beendet." << endl;
            break;
        default:
            cout << "Geben sie eine richtige Zahl ein." << endl;
        }
    } while (choice != 6);
}