package hurtownia;

import hurtownia.Main;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.FileWriter;
import java.io.IOException;

public class Myframe extends JFrame implements MouseListener {

    JFrame frame;
    JFrame newFrame;
    JButton addMaterial,removeMaterial,updateMaterial,displayAllMaterial;

    Myframe()
    {
        // creating frame

        frame = new JFrame();
        frame.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
        frame.setSize(new Dimension(900,700));
        frame.setLocationRelativeTo(null);  // we center our frame on the screen
        frame.setLayout(null);
        frame.getContentPane().setBackground(new Color(0x939597));
        frame.setResizable(false);


        // we perform operations on close of the window

        frame.addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent e) {
                // call terminate

                // zapis do pliku bedziemy realizowac na zamkniecie okna w Myframe

                FileWriter fileWriter = null;

                try {
                    fileWriter = new FileWriter(Main.filePath);
                    fileWriter.write(Main.myInventory.toString());
                }catch(Exception ex)
                {
                    System.out.println("Writing error - IO exception ");
                }
                finally {
                    if (fileWriter != null) {
                        try{
                            fileWriter.close();
                        }
                        catch(Exception ex)
                        {
                            System.out.println("File close error");
                        }

                    }
                }

                System.exit(0);
            }
        });

        // creating panel with subtitle ( header )

        JPanel header = new JPanel();
        header.setLayout(new BorderLayout());
        header.setBounds(0,0,frame.getWidth(),100);
        header.setBackground(new Color(0,0,0));

        JLabel subtitleHeader = new JLabel();
        subtitleHeader.setText("Hurtownia kamienia");
        subtitleHeader.setForeground(new Color(0xccd45d));
        subtitleHeader.setFont(new Font("Serif", Font.BOLD, 28));
        subtitleHeader.setHorizontalAlignment(JLabel.CENTER);
        subtitleHeader.setVerticalAlignment(JLabel.CENTER);

        header.add(subtitleHeader);
        frame.add(header);

        //  creating menu


        JPanel menuOuter = new JPanel();
        menuOuter.setBounds(0,header.getHeight(),frame.getWidth(),(700 - header.getHeight()));
        menuOuter.setLayout(new BorderLayout());
        menuOuter.setBackground(new Color(0x939597));
        frame.add(menuOuter);


        // adding spaces top left right bottom

        JPanel north = new JPanel();
        north.setBackground(new Color(0x939597));
        north.setPreferredSize(new Dimension(50,50));

        JPanel south = new JPanel();
        south.setBackground(new Color(0x939597));
        south.setPreferredSize(new Dimension(50,50));


        JPanel east = new JPanel();
        east.setBackground(new Color(0x939597));
        east.setPreferredSize(new Dimension(50,50));


        JPanel west = new JPanel();
        west.setBackground(new Color(0x939597));
        west.setPreferredSize(new Dimension(50,50));


        menuOuter.add(west,BorderLayout.WEST);
        menuOuter.add(east,BorderLayout.EAST);
        menuOuter.add(north,BorderLayout.NORTH);
        menuOuter.add(south,BorderLayout.SOUTH);

        JPanel menu = new JPanel();
        menu.setOpaque(true);
        menu.setBounds(0,header.getHeight(),frame.getWidth(),(700 - header.getHeight()));
        menu.setLayout(new GridLayout(2,2,50,50));
        menu.setBackground(new Color(0x939597));
        menuOuter.add(menu,BorderLayout.CENTER);



        // Buttons

        ImageIcon addImage = new ImageIcon("dodaj.png");
        ImageIcon removeImage = new ImageIcon("usun.png");
        ImageIcon updateImage = new ImageIcon("akutalizuj.png");
        ImageIcon displayImage = new ImageIcon("wyswietl.png");


        addMaterial = new JButton();
        addMaterial.setOpaque(true);
        addMaterial.setForeground(Color.BLACK);
        addMaterial.setBackground(new Color(0xccd45d));
        addMaterial.setBorder(BorderFactory.createEtchedBorder());
        addMaterial.setText("DODAJ");
        addMaterial.setHorizontalTextPosition(JButton.CENTER);
        addMaterial.setVerticalTextPosition(JButton.BOTTOM);
        addMaterial.setIcon(addImage);
        addMaterial.setFocusable(false);
        addMaterial.addMouseListener(this);
        menu.add(addMaterial);



        removeMaterial = new JButton();
        removeMaterial.setText("USUŃ");
        removeMaterial.setHorizontalTextPosition(JButton.CENTER);
        removeMaterial.setVerticalTextPosition(JButton.BOTTOM);
        removeMaterial.setBorder(BorderFactory.createEtchedBorder());
        removeMaterial.setOpaque(true);
        removeMaterial.setForeground(Color.black);
        removeMaterial.setBackground(new Color(0xccd45d));
        removeMaterial.setFocusable(false);
        removeMaterial.setIcon(removeImage);
        removeMaterial.addMouseListener(this);
        menu.add(removeMaterial);



        updateMaterial = new JButton();
        updateMaterial.setText("ZAAKTUALIZUJ");
        updateMaterial.setHorizontalTextPosition(JButton.CENTER);
        updateMaterial.setVerticalTextPosition(JButton.BOTTOM);
        updateMaterial.setBorder(BorderFactory.createEtchedBorder());
        updateMaterial.setOpaque(true);
        updateMaterial.setForeground(Color.black);
        updateMaterial.setBackground(new Color(0xccd45d));
        updateMaterial.setFocusable(false);
        updateMaterial.setIcon(updateImage);
        updateMaterial.addMouseListener(this);
        menu.add(updateMaterial);



        displayAllMaterial = new JButton();
        displayAllMaterial.setText("WYŚWIETL");
        displayAllMaterial.setHorizontalTextPosition(JButton.CENTER);
        displayAllMaterial.setVerticalTextPosition(JButton.BOTTOM);
        displayAllMaterial.setBorder(BorderFactory.createEtchedBorder());
        displayAllMaterial.setOpaque(true);
        displayAllMaterial.setForeground(Color.black);
        displayAllMaterial.setBackground(new Color(0xccd45d));
        displayAllMaterial.setFocusable(false);
        displayAllMaterial.setIcon(displayImage);
        displayAllMaterial.addMouseListener(this);
        menu.add(displayAllMaterial);




        frame.setVisible(true);



    }
/*
    @Override
    public void actionPerformed(ActionEvent e) {
        if(e.getSource() instanceof javax.swing.JButton ){System.out.println(e.getSource().getClass());}
    }

 */

    @Override
    public void mouseClicked(MouseEvent e) {

        if(e.getSource() == addMaterial)
        {
            if(newFrame != null)
            {
                newFrame.dispose();   // we prevent from opening a lot of new windows
            }

            newFrame = new addFrame();

        }
        else if(e.getSource() == removeMaterial)
        {
            if(newFrame != null)
            {
                newFrame.dispose();   // we prevent from opening a lot of new windows
            }

            newFrame = new removeFrame();

        }
        else if(e.getSource() == updateMaterial)
        {

            if(newFrame != null)
            {
                newFrame.dispose();   // we prevent from opening a lot of new windows
            }

            newFrame = new updateFrame();

        }
        else if(e.getSource() == displayAllMaterial)
        {
            if(newFrame != null)
            {
                newFrame.dispose();   // we prevent from opening a lot of new windows
            }

            newFrame = new displayFrame();

        }

    }

    @Override
    public void mousePressed(MouseEvent e) {

    }

    @Override
    public void mouseReleased(MouseEvent e) {

    }

    @Override
    public void mouseEntered(MouseEvent e) {
        if(e.getSource() instanceof javax.swing.JButton ){((JButton) e.getSource()).setBackground(new Color(0xbbc34c));}
    }

    @Override
    public void mouseExited(MouseEvent e) {
        if(e.getSource() instanceof javax.swing.JButton ){((JButton) e.getSource()).setBackground(new Color(0xccd45d));}
    }
}
