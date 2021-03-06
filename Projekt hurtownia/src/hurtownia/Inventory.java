package hurtownia;

import java.util.Arrays;
import java.util.Comparator;
import java.util.Scanner;

public class Inventory {

    private Material[] tableOfMaterials = new Material[50];
    private int numberOfElements = 50;
    static private int howManyMaterials = 0;
    private int indexOfTable = 0;


    static public int getHowManyMaterials()
    {
        return howManyMaterials;
    }

    public void sortInventory(Comparator<Material> cmp)
    {
        Arrays.sort(tableOfMaterials,cmp);
    }

    public Material getMaterialFromIndex(int index)
    {
        if(index < 0 || index >= howManyMaterials)
        {
            throw new ArrayIndexOutOfBoundsException();
        }

        return tableOfMaterials[index];
    }


    public Material getMaterialFromIndex(String materialName,float materialLength,float materialWidth)
    {
       for(int i=0;i<howManyMaterials;++i)
       {
           if(this.tableOfMaterials[i].getName().equals(materialName) && this.tableOfMaterials[i].getLength() == materialLength && this.tableOfMaterials[i].getWidth() == materialWidth)
           {
               return tableOfMaterials[i];
           }
       }

       return null;
    }


    public String toString()
    {

        var result = new StringBuffer();

        for(int i=0;i<this.indexOfTable;++i)
        {
            result.append(tableOfMaterials[i].toString());
        }

        return result.toString();
    }

    public void showAllMaterials()
    {
        for(int i=0;i<indexOfTable;++i)
        {
            System.out.print(i+1 + ".  ");
            this.tableOfMaterials[i].showInfo();
            System.out.println();
        }
    }



    public void setHowManyMaterials(int n)
    {
        if(n>=0)
        {
            this.howManyMaterials = n;
        }
    }

    public void setNumberOfElements(int n)
    {
        if(n>0)
        {
            this.numberOfElements = n;
        }
    }

    public void setIndexOfTable(int n)
    {
        if(n>0)
        {
            this.indexOfTable = n;
        }
    }

    public void setElementInTable(Material newObj)
    {
        if(newObj != null && (this.indexOfTable - 1) != numberOfElements)
        {
            this.tableOfMaterials[this.indexOfTable] = newObj;
            ++this.indexOfTable;
        }
        else   // we must extend size of our table
        {
            if(newObj != null) {
                Material[] temp = new Material[this.numberOfElements * 2];
                // we copy values of tables
                for (int i = 0; i < this.numberOfElements; ++i) {
                    temp[i] = this.tableOfMaterials[i];
                }

                this.numberOfElements = this.numberOfElements * 2;  // we extend size of table
                this.tableOfMaterials = temp;

                this.tableOfMaterials[this.indexOfTable] = newObj;
                ++this.indexOfTable;

            }


        }


        this.setHowManyMaterials(this.indexOfTable);


        // after every add we update sorted arrays of our table

        Arrays.sort(tableOfMaterials,(p,n)->
        {
            if(p == null || n == null)   // we have to deal with null objects
            {
                return 0;
            }
            return p.getName().compareTo(n.getName());

        });



        //System.out.println("Dodano materia?? do hurtowni\n");

    }


    public void removeMaterial(String nameMaterial,float width,float length)
    {
        for(int i=0;i<indexOfTable;++i)
        {
            String name = tableOfMaterials[i].getName();
            float wh = tableOfMaterials[i].getWidth();
            float len = tableOfMaterials[i].getLength();

            if(nameMaterial.equals(name) && wh == width && length == len)
            {
                Material[] updatedTable = new Material[this.numberOfElements];

                for(int j=0;j<i;++j)
                {
                    updatedTable[j] = this.tableOfMaterials[j];
                }

                for(int j=i;j<this.indexOfTable;++j)
                {
                    updatedTable[j] = this.tableOfMaterials[j+1];
                }

                this.indexOfTable--; // we removed item
                this.tableOfMaterials = updatedTable;

                System.out.println("Usuni??to materia??.. \n");
                this.setHowManyMaterials(this.indexOfTable);

                return;
            }

        }

        System.out.println("Nie znaleziono takiego materia??u..\n");


    }


    public void changeAmountOfMaterial(String nameMaterial,float width,float length,int newAmount)
    {



        for(int i=0;i<indexOfTable;++i)
        {
            if(nameMaterial.equals(this.tableOfMaterials[i].getName()) && width == this.tableOfMaterials[i].getWidth() && length == this.tableOfMaterials[i].getLength())
            {
                // trzeba sprawdidzc czy > 0
               // System.out.println("Wpisz aktualn?? ilo???? p??yt:");
                //Scanner sc = new Scanner(System.in);
                //int am = sc.nextInt();
                this.tableOfMaterials[i].setAmount(newAmount);

                System.out.println("Zmieniono ilo???? p??yt.. \n");
                return;
            }
        }
        System.out.println("Nie uda??o si?? znale???? podanej p??yty.. \n");
    }

}
