package hurtownia;

import javax.swing.*;
import java.io.*;
import java.util.Scanner;



// zrob odczyt i zapis do pliku hurtowni
public class Main {

    static Inventory myInventory = new Inventory(); // static because it will be used in other classes
    static String filePath = "hurtownia.txt";

    public static void main(String[] args) throws IOException {

        // tutaj mamy obsluge hurtowni z pliku  ( mozna zamienic na baze danych )


        //tutaj bedziemy musieli zaaktualizaowac nasza hurtownie ( z pliku) do obiektu klasy Inventory

        // odczyt


        BufferedReader fileReader = null;
        String nameOfMaterial = "";
        int numberOfMaterial = 0;
        float widthOfMaterial = 0;
        float lengthOfMaterial = 0;


        try {
            fileReader = new BufferedReader(new FileReader(filePath));
            String line = fileReader.readLine();

            int i = 0;
            while(line != null)
            {
                if(i%5==0){nameOfMaterial = line;}
                else if(i%5 == 1){numberOfMaterial = Integer.parseInt(line);}  // konwersja
                else if(i%5 == 2){widthOfMaterial = Float.parseFloat(line);}
                else if(i%5 == 3){lengthOfMaterial = Float.parseFloat(line);}
                else{myInventory.setElementInTable(new Material(nameOfMaterial,numberOfMaterial,widthOfMaterial,lengthOfMaterial));}



                // read next line
                line = fileReader.readLine();
                ++i;
            }



        } finally {
            if (fileReader != null) {
                fileReader.close();
            }
        }



        // prowizoryczne gui w konsoli -----------

/*

        System.out.println("Witaj użytkowniku!");

        int reply;
        do {

            Scanner scan = new Scanner(System.in);

            System.out.println("Wybierz odpowiedni nr menu widoczny na ekranie, aby podjąć pożądane działanie");
            System.out.println("1 - dodaj nowy materiał");
            System.out.println("2 - usun wybrany material");
            System.out.println("3 - wyswietl wszystkie materialy hurtowni");
            System.out.println("4 - zmien ilosc danego materialu");
            System.out.println("0 - zamknij program\n");

            reply = scan.nextInt();


            switch(reply)
            {
                case 0:
                    break;

                case 1:

                    // trzeba zrobic wariunki na > 0

                    Scanner replyMaterial = new Scanner(System.in);
                    System.out.println("Podaj nazwę materiału");
                    String material = replyMaterial.nextLine();

                    System.out.println("Długość płyty:");
                    float length = replyMaterial.nextFloat();

                    System.out.println("Szerokość płyty:");
                    float width = replyMaterial.nextFloat();

                    System.out.println("Ilość płyt:");
                    int amount = replyMaterial.nextInt();

                    myInventory.setElementInTable(new Material(material,amount,width,length));
                    break;

                case 2:

                    Scanner replyMl = new Scanner(System.in);
                    System.out.println("Podaj nazwę materiału");
                    String mat = replyMl.nextLine();

                    System.out.println("Długość płyty:");
                    float len = replyMl.nextFloat();

                    System.out.println("Szerokość płyty:");
                    float wid = replyMl.nextFloat();

                    myInventory.removeMaterial(mat,wid,len);
                    break;

                case 3:  // przy wyswietlaniu mozna zrobic aktualiacje, ze sprawdza ilosc i jak jakichs jest zero to usuwa autoamtycznie
                    // wtedy trzeba ukryc info o usunieciu
                    System.out.println("\nWszystkie materiały hurtowni: ");
                    myInventory.showAllMaterials();

                    break;

                case 4:

                    Scanner replyMat = new Scanner(System.in);
                    System.out.println("Podaj nazwę materiału");
                    String m = replyMat.nextLine();

                    System.out.println("Długość płyty:");
                    float l = replyMat.nextFloat();

                    System.out.println("Szerokość płyty:");
                    float w = replyMat.nextFloat();

                    myInventory.changeAmountOfMaterial(m,w,l);

                    break;

            }

        }
        while( reply != 0 );


 */

        // zapis do pliku bedziemy realizowac na zamkniecie okna w Myframe
        /*
        FileWriter fileWriter = null;

        try {
            fileWriter = new FileWriter(filePath);
            fileWriter.write(myInventory.toString());
        } finally {
            if (fileWriter != null) {
                fileWriter.close();
            }
        }
*/

        Myframe frame = new Myframe();



    }
}
