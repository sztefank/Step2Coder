#include <iostream> // alles mit einem # davor ist ein "preprocessor" - heißt es wird vor der kompilierung ausgeführt
#include <vector>

using namespace std; // erspart das std:: bei cin/cout/string/endl

// int i; deklaration
// int i = 0; definition

// datentypen: int(zahlen) - double(floats/zahlen mit decimal stellen) - char(string aber für nur einen buchstaben) - string(buchstaben) - bool(true oder false) - const(konstanter wert der nicht geändert werden kann)
// * sind pointer (noch nicht ganz verstanden)
// alle variablen außerhalb von funktionen sind global 
int i;
string input; 
int choice;
int zahl_array[5] = {1, 2, 3, 4, 5}; // arrays natürlich mit bestimmter größe, nicht möglich nur zu deklarieren ohne größe :( außer man benutzt pointer  - array indexing mit []
string* wort_Array[]; // so muss man nicht direkt die größe bestimmen 
vector<int> zahl_vector; // vectoren sind arrays mit unbestimmer größe (muss man inkludieren)

int main()
{
    cout << "Hello World!\n"; // Console.WriteLine(); fake
    cin >> input;             // Console.ReadLine(); fake - speichert die eingabe in der variable input
    cout << input << endl;

    for (i = 0; i < 1; i++) // for schleife
    {
        cout << "for loop" << endl;
    }

    cout << "Druecke 1 oder 2" << endl;

    cin >> choice;

    if (choice == 1) // if statement 
    {
        cout << "Du hast 1 gedrueckt" << endl;
    }
    else if (choice == 2) // else if statement
    {
        cout << "Du hast 2 gedrueckt" << endl;
    }
    else  // else statement 
    {
        cout << "Du hast weder 1 noch 2 gedrueckt" << endl;
    }

    do // do while schleife
    {
        cout << "do while loop" << endl;
                                       
        break; // aus schleifen ausbrechen

    } while (true);

    while (true) // while schleife 
    {
        cout << "while loop" << endl;
        
        break;
    }

    for (int zahl : zahl_array) // foreach loop
    {
        cout << "foreach loop" << endl;
    }

    zahl_vector.push_back(1); // ein element am ende in einen vector hinzufügen 

    zahl_vector.insert(zahl_vector.begin(), 0); // ein element an einer bestimmten stelle hinzufügen

    cout << zahl_vector[0]; // vector indexing genau wie bei arrays 

    zahl_vector.pop_back(); // das letzte element aus einem vector hinzufügen

    zahl_vector.erase(zahl_vector.begin() + 0); // ein element auf einer bestimmten stelle entfernen 

    switch (choice) // switches
    {
    case 1:
        break;
    case 2:
        break;
    case 3:
        break;
    default:
        break;
    }

    return 0; // die main funktion beenden
}

