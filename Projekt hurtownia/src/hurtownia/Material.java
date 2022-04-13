package hurtownia;

// rozrozniamuy plyty przez nazwe oraz wymiary!
public class Material {

    private String nameOfMaterial;
    private int howMany;
    private float width;
    private float length;

    Material(String name,int amount,float width,float length)
    {
        // warunki > 0

        this.nameOfMaterial = name;
        this.howMany = amount;
        this.width = width;
        this.length = length;

    }

    public void showInfo()
    {
        System.out.println("Materiał: " + nameOfMaterial );
        System.out.println("Ilość materiału: " + howMany );
        System.out.println("Szerokość płyty: " + width);
        System.out.println("Długość płyty: " + length);

    }

    public String toString()
    {
        /*return "Materiał: " + this.nameOfMaterial + "\nIlość materiału: " + this.howMany + "\n Szerokość płyty: " + this.width + "\nDługość płyty: " + this.length + "\n\n";*/
        return this.nameOfMaterial + "\n" + this.howMany + "\n" + this.width + "\n" + this.length + "\n\n";
    }

    public String getName()
    {
        return nameOfMaterial;
    }

    public int getAmount()
    {
        return howMany;
    }

    public float getWidth()
    {
        return width;
    }

    public float getLength()
    {
        return length;
    }


    public void setAmount(int newAmount)
    {
        if(newAmount > 0 && newAmount != this.howMany )
        {
            this.howMany = newAmount;
        }
    }



}
