// ----------- VARIABILI GLOBALI ------------
int massimaCapienzaAula = 10;
int postiDisponibili = 0;

string[] nomeAlunni = new string[massimaCapienzaAula];
string[] cognomeAlunni = new string[massimaCapienzaAula];
int[] etaAlunni = new int[massimaCapienzaAula];


// ------------- LE MIE FUNZIONI ------------

void StampaNomiAlunni()
{
    for (int i = 0; i < postiDisponibili; i++)
    {
        Console.Write("[" + (i + 1) + "- " + nomeAlunni[i] + "]");
    }
    Console.WriteLine();
}

void StampaCognomiAlunni()
{
    for (int i = 0; i < postiDisponibili; i++)
    {
        Console.Write("[" + (i + 1) + "- " + cognomeAlunni[i] + "]");
    }
    Console.WriteLine();
}

void StampaEtaAlunni()
{
    for (int i = 0; i < postiDisponibili; i++)
    {
        Console.Write("[" + (i + 1) + "- " + etaAlunni[i] + "]");
    }
    Console.WriteLine();
}

void aggiungiAlunno(string nome, string cognome, int eta)
{
    if (postiDisponibili < massimaCapienzaAula)
    {

        nomeAlunni[postiDisponibili] = nome;
        cognomeAlunni[postiDisponibili] = cognome;
        etaAlunni[postiDisponibili] = eta;
        postiDisponibili++;

    }
    else
    {
        Console.WriteLine("Mi dispiace ma l'aula e' piena!");
    }
}

void eliminaAlunno()
{
    if (postiDisponibili > 0)
    {
        postiDisponibili--;
        nomeAlunni[postiDisponibili] = "";
        cognomeAlunni[postiDisponibili] = "";

    }
    else
    {
        Console.WriteLine("Mi dispiace ma non hai più auto!");
    }
}

int sommaEta(int[] array)
{
    int somma = 0;
    for (int i = 0; i < array.Length; i++)
    {
        somma += array[i];
    }
    return somma;
}

float calcolaEtaMediaClasse(int[] array)
{
    int sommaArray = sommaEta(array);
    float mediaArray = (float)sommaArray / postiDisponibili;
    return mediaArray;
}

int EtaPiuGiovane()
{
    int min = etaAlunni[0];
    for (int i = 1; i < etaAlunni.Length; i++)
    {
        if (etaAlunni[i] < min)
        {
            min = etaAlunni[i];
        }
    }
    return min;
    
}
int EtaPiuVecchio()
{
    int max = etaAlunni[0];
    for (int i = 1; i < etaAlunni.Length; i++)
    {
        if (etaAlunni[i] > max)
        {
            max = etaAlunni[i];
        }
    }
    return max;
}
    // ------------- PROGRAMMA PRINCIPALE -------------
Console.WriteLine("Il numero di alunni in classe è: " + postiDisponibili);
bool uscitaDalWhile = true;

while (uscitaDalWhile)
{
    Console.Write("Vuoi aggiungere o rimuovere un alunno dalla classe [aggiungi/rimuovi/completa/stats]? ");
    string risposta = Console.ReadLine();

    switch (risposta)
    {
        case "aggiungi":
            Console.WriteLine("Nome dell'alunno:");
            string nome = Console.ReadLine();
            Console.WriteLine("Cognome dell'alunno:");
            string cognome = Console.ReadLine();
            Console.WriteLine("Eta dell'alunno:");
            int eta = int.Parse(Console.ReadLine());
            aggiungiAlunno(nome, cognome, eta);
            break;

        case "rimuovi":
            eliminaAlunno();
            break;

        case "completa":
            Console.WriteLine("Smetteremo di aggiungere e rimuovere");
            uscitaDalWhile = false;
            break;

        case "stats":
            float media = calcolaEtaMediaClasse(etaAlunni);
            Console.WriteLine("La media delle eta' e': " + media);
            int etaMinore = EtaPiuGiovane();
            Console.WriteLine("Il piu giovane e': " + etaMinore);
            int etaMaggiore = EtaPiuVecchio();
            Console.WriteLine("Il piu giovane e': " + etaMaggiore);
            break;

        default:
            Console.WriteLine("Opzione non consentita");
            break;
    }
    Console.WriteLine("Il numero di alunni in classe è: " + postiDisponibili);

    StampaNomiAlunni();
    StampaCognomiAlunni();
    StampaEtaAlunni();
}

