#include <stdio.h>
#define rozmiar 10
#define WYGRANA 250
#define PRZEGRANA -250
#define remis 0


void wyczysc(char plansza[rozmiar][rozmiar]);
void wypisz(char plansza[rozmiar][rozmiar]);
int generatornajlepszegoruchu(char tablica[rozmiar][rozmiar],char znakgracza,int glebia);
int najlepszywiersz,najlepszakolumna; //globalne
int ocena(char plansza[rozmiar][rozmiar]);
int dzialajwpoblizu(char plansza[rozmiar][rozmiar],int m,int n);
int tablicawartoscix[6]={0,1,20,30,40,WYGRANA};
int tablicawartosciy[6]={0,-1,-20,-30,-40,PRZEGRANA};


int main(){
    /*int i,j;
    char tablica[rozmiar][rozmiar];
    wyczysc(tablica); //zapelnia pustymi polami
    for(i=0;i<1;i++)
    {
        for(j=3;j<5;j++)
        {
            tablica[j][i]='x';
        }
    }
    for(i=2;i<3;i++)
    {
        for(j=3;j<6;j++)
        {
            tablica[j][i]='x';
        }
    }
    tablica[0][0]='o';
    tablica[1][0]='o';

    tablica[5][0]='x';
    tablica[6][1]='x';
    tablica[7][2]='x';
    tablica[8][3]='x';
    tablica[9][4]='x';


    wypisz(tablica);

    printf("\n\n%d\n",ocena(tablica)); */



    char plansza[rozmiar][rozmiar];
    wyczysc(plansza);
    int w,k,aktualnystangry=remis,obecniezajetepola=0;
    wypisz(plansza);
    
    while(aktualnystangry != WYGRANA && aktualnystangry != PRZEGRANA && obecniezajetepola<100)
    {

        printf("Wpisz nr wiersza i kolumny, w które chcesz postawić swojego 'o' \n");
        scanf("%d %d",&w,&k);
        if(plansza[w][k]==' ')
        {
            plansza[w][k]='o';
        }
        else
        {       while(plansza[w][k]!=' '){
                printf("Podaj jeszcze raz, gdyż to pole jest niestety zajęte! \n");
                scanf("%d %d",&w,&k);}

                plansza[w][k]='o';



        }

        ++obecniezajetepola;
        generatornajlepszegoruchu(plansza,'x',4);
        plansza[najlepszywiersz][najlepszakolumna]='x';
        ++obecniezajetepola;
        wypisz(plansza);
        aktualnystangry = ocena(plansza);

    }
    if(aktualnystangry==PRZEGRANA) printf("Wygrało o! Koniec \n");
    else if(aktualnystangry==WYGRANA) printf("Wygrał x! Koniec \n");
    else printf("Niestety remis! Koniec \n");

/*
    char plansza[rozmiar][rozmiar];
    wyczysc(plansza);

    plansza[8][4]='o';
    plansza[7][5]='x';
    plansza[6][6]='x';
    plansza[5][7]='x';
    plansza[4][8]='x';
    plansza[3][9]='x';


    wypisz(plansza);
    printf("Ocna tablicy %d",ocena(plansza));*/


    // sprawdza podciagi ta petla

    /*for(int m=5;m<=5;m++){
    for(int i=1;i<=1;i++){
            suma=0;
            for(int j=0;j+i+m<rozmiar;j++)
            {
                plansza[9-i-j-m][j+m]='x';

            }

        }}

    wypisz(plansza);*/

    return 0;
}









void wypisz(char plansza[rozmiar][rozmiar]){
    int i,j;
    printf("  0  1  2  3  4  5  6  7  8  9\n");
    for(i=0;i<rozmiar;i++)
    {   printf("-------------------------------\n");
        for(j=0;j<rozmiar;j++)
        {   if(j==0) printf("%d|%c|",i,plansza[i][j]);
            else printf("|%c|",plansza[i][j]);
        }
        printf("\n");
    }
    printf("-------------------------------\n");
}




void wyczysc(char plansza[rozmiar][rozmiar]){
    int i,j;
    for(i=0;i<rozmiar;i++)
    {
        for(j=0;j<rozmiar;j++)
        {
            plansza[i][j]=' ';
        }
        printf("\n");
    }
}


int ocena(char plansza[rozmiar][rozmiar]){

int i,j;
int sumawartosci=0;
int suma;
//wiersze dla x  p - podciag
for(int p=0;p<=rozmiar/2;p++) // ostatni mozliwy podciag
{
    for(int i=0;i<rozmiar;i++)
    {   suma=0;                         //w kazdym wierszu liczymy kolejne wystapienia
        for(int j=0;j+p<rozmiar;j++)  //warunek aby nie wychodzilo za plansze
        {
            if(plansza[i][j+p]=='x')
            {
                suma++;
                if(suma==5) return WYGRANA;
            }
            else break;

        }

        sumawartosci+=tablicawartoscix[suma];

        }
    }



for(int p=0;p<=rozmiar/2;p++) // wiersze dla o ostatni mozliwy podciag
{
    for(int i=0;i<rozmiar;i++)
    {   suma=0;                         //w kazdym wierszu liczymy kolejne wystapienia
        for(int j=0;j+p<rozmiar;j++)  //warunek aby nie wychodzilo za plansze
        {
            if(plansza[i][j+p]=='o')
            {
                suma++;
                if(suma==5) return PRZEGRANA;
            }
            else break;

        }


            sumawartosci+=tablicawartosciy[suma];

    }
}

//sprawdzanie kolumn z podciagiem dla x


for(int p=0;p<=rozmiar/2;p++) // ostatni mozliwy podciag
{
    for(int i=0;i<rozmiar;i++)
    {   suma=0;                         //w kazdym wierszu liczymy kolejne wystapienia
        for(int j=0;j+p<rozmiar;j++)  //warunek aby nie wychodzilo za plansze
        {
            if(plansza[j+p][i]=='x')
            {
                suma++;
                if(suma==5) return WYGRANA;
            }
            else break;

        }

            sumawartosci+=tablicawartoscix[suma];

    }
}


// kolumny z podciagiem dla o
for(int p=0;p<=rozmiar/2;p++) // ostatni mozliwy podciag
{
    for(int i=0;i<rozmiar;i++)
    {   suma=0;                         //w kazdym wierszu liczymy kolejne wystapienia
        for(int j=0;j+p<rozmiar;j++)  //warunek aby nie wychodzilo za plansze
        {
            if(plansza[j+p][i]=='o')
            {
                suma++;
                if(suma>=5) return PRZEGRANA;
            }
            else break;

        }

            sumawartosci+=tablicawartosciy[suma];

    }
}





/*for(i=0;i<rozmiar;i++)           //sprawdzam kolumny
    {
        for(j=0;j<=rozmiar/2;j++)
        {   if(plansza[j][i]=='o'){   //5 pod rzad o
            if(plansza[j+1][i]==plansza[j][i] && plansza[j+2][i] == plansza[j][i] && plansza[j+3][i] == plansza[j][i] && plansza[j+4][i] == plansza[j][i] )
                {
                    return PRZEGRANA;
                }
        }

            else{
                if(plansza[j][i]=='x'){           //5 pod rzad x
                if(plansza[j+1][i] == plansza[j+1][i] && plansza[j+2][i] == plansza[j][i] && plansza[j+3][i] == plansza[j][i] && plansza[j+4][i] == plansza[j][i] )
                return WYGRANA;
            }}
        }

    }



for(i=0;i<rozmiar;i++)
{
    for(j=0;j<rozmiar;j++)
    {

    }
}




    for(i=0;i<rozmiar;i++)      //sprawdzam wiersze
{
    for(j=0;j<=rozmiar/2;j++)
    {
        if(plansza[i][j]=='o')
        {
            if(plansza[i][j+1] == plansza[i][j] && plansza[i][j+2] == plansza[i][j] && plansza[i][j+3] == plansza[i][j] && plansza[i][j+4] == plansza[i][j] )
            {
                return PRZEGRANA;
            }
        }
        else if(plansza[i][j]=='x')
        {
            if(plansza[i][j+1] == plansza[i][j] && plansza[i][j+2] == plansza[i][j] && plansza[i][j+3] == plansza[i][j] && plansza[i][j+4] == plansza[i][j] )
            {
                return WYGRANA;
            }
        }
    }
}

*/


       //warunek na przegrana po skosie z lewej w dol dla x
for(int m=0;m<=rozmiar/2;m++){ // sprawdza podciagi ta petla
    for(int i=0;i<=5;i++){  // <=5, bo to ostatnia szansa z lewej na wygrana
            suma=0;
            for(int j=0;m+j+i<rozmiar;j++) //j+i warunek aby nie wyszedl poza tablice
            {
                if(plansza[j+i+m][j+m]=='x')
                { suma++;
                 if(suma==5) return WYGRANA;}

                else break;                     //warunek,aby po kolei było 5
            }


            sumawartosci+=tablicawartoscix[suma];

        }}




     for(int m=0;m<=rozmiar/2;m++){
            //warunek na wygrana po skosie z lewej w dol dla o
    for(int i=0;i<=5;i++){  // <=5, bo to ostatnia szansa z lewej na wygrana
            suma=0;
            for(int j=0;j+i+m<rozmiar;j++) //j+i warunek aby nie wyszedl poza tablice
            {
                if(plansza[j+i+m][j+m]=='o')
                { suma++;
                if(suma==5) return PRZEGRANA;}
                else break;                     //warunek,aby po kolei było 5
            }

            sumawartosci+=tablicawartosciy[suma];
             //moze byc wiecej niz 5 i tez bedzi wygrana
        }}


            //warunek na przegrana po skosie w prawo gore

     for(int m=0;m<=rozmiar/2;m++){
    for(int i=0;i<=5;i++){  // <=5, bo to ostatnia szansa z lewej na wygrana
        suma=0;
        for(int j=0;j+i+m<rozmiar;j++) //j+i warunek aby nie wyszedl poza tablice
        {
            if(plansza[j+m][j+i+m]=='x')
            { suma++;
              if(suma==5) return WYGRANA;}
            else break;                     //warunek,aby po kolei było 5
        }


            sumawartosci+=tablicawartoscix[suma];

    }}

            //warunek na wygrana po skosie w prawo gore

     for(int m=0;m<=rozmiar/2;m++){
    for(int i=0;i<=5;i++){  // <=5, bo to ostatnia szansa z lewej na wygrana
        suma=0;
        for(int j=0;j+i+m<rozmiar;j++) //j+i warunek aby nie wyszedl poza tablice
        {
            if(plansza[j+m][j+i+m]=='o'){
            suma++;
            if(suma==5) return PRZEGRANA;}
            else break;                     //warunek,aby po kolei było 5
        }

            sumawartosci+=tablicawartosciy[suma];

    }}



     for(int m=0;m<=rozmiar/2;m++){            //warunek na przegrana po skosie w prawo (odwrocone)
    for(int i=0;i<=5;i++){  // <=5, bo to ostatnia szansa z lewej na wygrana
        suma=0;
        for(int j=0;j+i+m<rozmiar;j++) //j+i warunek aby nie wyszedl poza tablice
        {
            if(plansza[9-j-m][j+i+m]=='x'){
             suma++;
              if(suma==5) return WYGRANA;}
            else break;                     //warunek,aby po kolei było 5
        }

            sumawartosci+=tablicawartoscix[suma];

    }}



     for(int m=0;m<=rozmiar/2;m++){          //warunek na wygrana po skosie w prawo (odwrocone)
    for(int i=0;i<=5;i++){  // <=5, bo to ostatnia szansa z lewej na wygrana
        suma=0;
        for(int j=0;j+i+m<rozmiar;j++) //j+i warunek aby nie wyszedl poza tablice
        {
            if(plansza[9-j-m][j+i+m]=='o'){
            suma++;
             if(suma==5) return PRZEGRANA;}
            else break;                     //warunek,aby po kolei było 5
        }

            sumawartosci+=tablicawartosciy[suma];

    }}



     for(int m=0;m<=rozmiar/2;m++){       //warunek na przegrana po skosie w lewo w gore (odwrocone)
    for(int i=0;i<=5;i++){  // <=5, bo to ostatnia szansa z lewej na wygrana
        suma=0;
        for(int j=0;j+i+m<rozmiar;j++) //j+i warunek aby nie wyszedl poza tablice
        {
            if(plansza[9-i-j-m][j+m]=='x'){
             suma++;
              if(suma==5) return WYGRANA;}
            else break;                     //warunek,aby po kolei było 5
        }

            sumawartosci+=tablicawartoscix[suma];

    }}



     for(int m=0;m<=rozmiar/2;m++){       //warunek na wygrana po skosie w lewo w gore(odwrocone)
    for(int i=0;i<=5;i++){  // <=5, bo to ostatnia szansa z lewej na wygrana
        suma=0;
        for(int j=0;j+i<rozmiar;j++) //j+i warunek aby nie wyszedl poza tablice
        {
            if(plansza[9-i-j-m][j+m]=='o'){
            suma++;
            if(suma==5) return PRZEGRANA;}
            else break;                     //warunek,aby po kolei było 5
        }


            sumawartosci+=tablicawartosciy[suma];

    }}



    return sumawartosci; //gdy, nie bedzie ani wygranej ani przegranej

}






int generatornajlepszegoruchu(char tablica[rozmiar][rozmiar],char znakgracza,int glebia){


    int ocenwygrana=ocena(tablica),dotychczaszajetepola=0; // oceniamy aktualy stan
    if(ocenwygrana==WYGRANA || ocenwygrana==PRZEGRANA || glebia==0) return ocenwygrana; //sprawdza czy juz gra sie nie zakonczyla

    int aktualnaocena,najlepszaopcja;
    if(znakgracza=='o') najlepszaopcja=WYGRANA + 100; //patrzymy pod wzgledem przeciwnika, będzie on dązył do jak najmbniejszego wyniku
    else najlepszaopcja=PRZEGRANA - 100; //my będziemy maksymalizować nasz ruch

    for(int i=0;i<rozmiar;i++)
    {
        for(int j=0;j<rozmiar;j++){
            if(tablica[i][j] == ' ' && dzialajwpoblizu(tablica,i,j)) // analizujemy ruch i optymalizujemy
            {
                tablica[i][j]=znakgracza;
                if(znakgracza=='x')
                {
                    aktualnaocena=generatornajlepszegoruchu(tablica,'o',glebia-1);
                }
                else if(znakgracza = 'o')
                {
                    aktualnaocena=generatornajlepszegoruchu(tablica,'x',glebia-1);
                }
                tablica[i][j]=' ';  //czyscimy zajete pola
                if(znakgracza=='x' && aktualnaocena>najlepszaopcja) //ruch AI maksymalizujemy
                {
                    najlepszaopcja=aktualnaocena;
                    if(glebia==4) // wyloni najlepszy ostateczny ruch
                    {
                        najlepszywiersz=i;
                        najlepszakolumna=j;
                    }
                }

                else if(znakgracza=='o' && aktualnaocena<najlepszaopcja) // patrzymy z perspektywy AI wiec ten ruch minimalizujemy
                {
                    najlepszaopcja=aktualnaocena;
                }

            }
            else {++dotychczaszajetepola;}
        }
    }

    if(dotychczaszajetepola>99) {return ocenwygrana;}
    return najlepszaopcja;

}

int dzialajwpoblizu(char plansza[rozmiar][rozmiar],int m,int n) //optymalizacja ruchu rozpatruje ruchy gdzie wokol cos jest, bo glebokosc nie jest duza
{   // badamy wszystkie mozliwe pozycje wokol naszego wybranego miejsca
    if(plansza[m][n+1]!=' ' && n+1<rozmiar) //prawo od naszego miejsca
        return 1;
    if(plansza[m+1][n]!=' ' && m+1 < rozmiar) //dol
        return 1;
    if(plansza[m][n-1]!=' ' && n-1>=0) //lewo
        return 1;
    if(plansza[m-1][n]!=' ' && m-1>=0) // gora
        return 1;
    if(plansza[m+1][n+1]!=' '&& m+1<rozmiar && n+1<rozmiar)  //lewy dolny
        return 1;
    if(plansza[m-1][n+1]!=' ' && m-1 >= 0 && n+1<rozmiar) //prawy gorny
        return 1;
    if(plansza[m-1][n-1]!=' ' && m-1>=0 && n-1>=0) //lewy gorny
        return 1;
    if(plansza[m+1][n-1]!=' ' && m+1<rozmiar && n-1>=0) //lewy dolny
        return 1;

    return 0; // gdy nie wejdzie w ifa to nie znalazl takiego punktu

}


