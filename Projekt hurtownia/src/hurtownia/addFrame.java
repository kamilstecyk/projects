package hurtownia;

import hurtownia.Main;
import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.border.LineBorder;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.TimeUnit;

public class addFrame extends JFrame implements MouseListener {

    JButton backButton;
    JButton submitBtn;
    JTextField[] fields = new JTextField[4];
    JPanel addPanel;   // main panel in the frame
    Border border = new LineBorder(Color.BLACK, 2, true);
    JPanel space1;  // it will be message when button is clioked
    JLabel message;
    String[] tableOfNames = {"Nazwa materiału","Ilość materiału","Długość materiału","Szerokość materiału"};



    addFrame()
    {

        this.setSize(new Dimension(900,700));
        this.setLocationRelativeTo(null);
        this.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);  // because we get back to previous one
        this.setLayout(null);
        this.getContentPane().setBackground(new Color(0x939597));
        this.setResizable(false);
        this.setUndecorated(true);  // stanard bar at the top of frame

        // header


        // creating panel with subtitle ( header )

        JPanel header = new JPanel();
        header.setLayout(new BorderLayout());
        header.setBounds(0,0,this.getWidth(),100);
        header.setBackground(new Color(0,0,0));

        JLabel subtitleHeader = new JLabel();
        subtitleHeader.setText("Hurtownia kamienia");
        subtitleHeader.setForeground(new Color(0xccd45d));
        subtitleHeader.setFont(new Font("Serif", Font.BOLD, 28));
        subtitleHeader.setHorizontalAlignment(JLabel.CENTER);
        subtitleHeader.setVerticalAlignment(JLabel.CENTER);

        header.add(subtitleHeader);
        this.add(header);


        // back button to the menu frame


        ImageIcon backImage = new ImageIcon("powrot.png");

        backButton = new JButton();
        backButton.setBounds(800,20,60,60);
        backButton.setBorder(BorderFactory.createEtchedBorder());
        backButton.setOpaque(true);
        backButton.setBackground(new Color(0xccd45d));
        backButton.setIcon(backImage);
        backButton.addMouseListener(this);
        this.add(backButton);



        //  we are creating panel for adding material for inventory

        addPanel = new JPanel();
        addPanel.setBounds(0,header.getHeight(),this.getWidth(),this.getHeight()-header.getHeight());
        addPanel.setBackground(new Color(0x939597));
        addPanel.setLayout(new ModifiedFlowLayout(ModifiedFlowLayout.CENTER,30,30));

        // space which will be message

        space1 = new JPanel();
        space1.setPreferredSize(new Dimension(this.getWidth(),55));
        space1.setOpaque(true);
        space1.setBackground(new Color(0x939597));  // new Color(0x939597)
        space1.setLayout(new FlowLayout());  // to center later label with text

        addPanel.add(space1);

        ImageIcon infoImage = new ImageIcon("info.png");

        message = new JLabel();
        message.setOpaque(true);
        message.setIcon(infoImage);
        message.setHorizontalAlignment(JLabel.CENTER);
        message.setVerticalAlignment(JLabel.CENTER);
        message.setBorder(border);
        message.setBackground(new Color(0xccd45d));  // new Color(0xccd45d)
        message.setForeground(Color.BLACK);
        message.setPreferredSize(new Dimension(300,50));
        message.setVisible(false);

        space1.add(message);


        for(int i=0;i<tableOfNames.length;++i)
        {
            fields[i] = new JTextField();
            fields[i].setPreferredSize(new Dimension(600,60));
            fields[i].setBackground(Color.BLACK);
            fields[i].setText(tableOfNames[i]);
            fields[i].setCaretColor(new Color(0xccd45d));
            fields[i].setForeground(new Color(0x99a12a));
            fields[i].setHorizontalAlignment(JTextField.CENTER);
            fields[i].setBorder(border);
            fields[i].addMouseListener(this);
            addPanel.add(fields[i]);
        }

        // we add button to add Material to inventory


        submitBtn = new JButton();
        submitBtn.setBorder(border);
        submitBtn.setBackground(new Color(0xccd45d));
        submitBtn.setFont(new Font("Consolas",Font.BOLD,16));
        submitBtn.setText("Dodaj materiał".toUpperCase());
        submitBtn.setPreferredSize(new Dimension(300,80));
        submitBtn.setOpaque(true);
        submitBtn.addMouseListener(this);

        addPanel.add(submitBtn);




        this.add(addPanel);

        this.setVisible(true);





    }



    @Override
    public void mouseClicked(MouseEvent e) {

        if(e.getSource() == backButton )
        {
            this.dispose();  // we close this frame
        }

        if(e.getSource() instanceof JTextField)
        {
            ((JTextField) e.getSource()).setForeground(new Color(0xccd45d));
            ((JTextField) e.getSource()).setText("");  // not to have to delete placeholder
        }

        if(e.getSource() == submitBtn)
        {

            StringBuffer msg = new StringBuffer();  // for optimization
            boolean everythingGood = true;
            boolean isConvertionGood = true;
            String materialName = "";
            int materialAmount = 0;
            float materialLength = 0;
            float materialWidth = 0;

            for(int i=0;i<fields.length;++i)  // we check if fields are not empty or have placeholder
            {
                if( fields[i].getText().equals("") || fields[i].getText().equals(tableOfNames[i]) )
                {
                    everythingGood = false;
                    msg.append("Pola są puste lub nieuzupełnione!");
                    break;   // to optimize
                }

            }



            if(everythingGood)
            {
                // we handle inappropriate inputs of user

                if(isConvertionGood) {  // this is for optimization, if we have not sth good then it is senseless to check next ( exceptions are expensive )
                    try {   // we check if string only contains letters because it is name of material and otherwise we throw expection

                        materialName = fields[0].getText();
                        if(!materialName.matches("^[\\s\\p{L}]+$"))  // regexp
                        {
                            throw new Exception();
                        }

                    } catch (Exception ex) {
                        msg.append("Wpisałeś niewłaściwe dane!");
                        isConvertionGood = false;
                    }
                }


                if(isConvertionGood) {  // this is for optimization, if we have not sth good then it is senseless to check next ( exceptions are expensive )
                    try {
                        materialAmount = Integer.parseInt(fields[1].getText());
                    } catch (Exception ex) {
                        msg.append("Wpisałeś niewłaściwe dane!");
                        isConvertionGood = false;
                    }
                }


                if(isConvertionGood) {  // this is for optimization, if we have not sth good then it is senseless to check next ( exceptions are expensive )
                    try {
                        materialLength = Float.parseFloat(fields[2].getText());
                    } catch (Exception ex) {
                        msg.append("Wpisałeś niewłaściwe dane!");
                        isConvertionGood = false;
                    }
                }

                if(isConvertionGood) {  // this is for optimization, if we have not sth good then it is senseless to check next ( exceptions are expensive )
                    try {
                        materialWidth = Float.parseFloat(fields[3].getText());
                    } catch (Exception ex) {
                        msg.append("Wpisałeś niewłaściwe dane!");
                        isConvertionGood = false;
                    }
                }


                if(isConvertionGood)
                {

                    // we add material to myInventory  ( object )

                    Material newMaterial = new Material(materialName,materialAmount,materialWidth,materialLength);
                    Main.myInventory.setElementInTable(newMaterial);


                    message.setText("Dodano pomyślnie materiał!");
                    message.setVisible(true);

                    // we want to hide our message after some delay
                    CompletableFuture.delayedExecutor(1, TimeUnit.SECONDS).execute(() -> {
                        message.setVisible(false);
                    });

                    // we want to set our fields default

                    for(int i=0;i<fields.length;++i)
                    {
                        fields[i].setText(tableOfNames[i]);
                    }

                }
                else
                {
                    message.setText(msg.toString());
                    message.setVisible(true);

                    // we want to hide our message after some delay
                    CompletableFuture.delayedExecutor(1, TimeUnit.SECONDS).execute(() -> {
                        message.setVisible(false);
                    });

                }

            }
            else
            {
                message.setText(msg.toString());
                message.setVisible(true);

                // we want to hide our message after some delay
                CompletableFuture.delayedExecutor(1, TimeUnit.SECONDS).execute(() -> {
                    message.setVisible(false);
                });

            }




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
