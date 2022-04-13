package hurtownia;

import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.border.LineBorder;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.TimeUnit;

public class updateFrame  extends JFrame implements MouseListener {


    JButton backButton;
    JPanel space1;  // it will be message when button is clioked
    JLabel message;
    Border border = new LineBorder(Color.BLACK, 2, true);
    JPanel allMaterials;
    JTextField inputField;
    JButton acceptBtn;
    JButton backBtn;
    List<JLabel> fields = new ArrayList<JLabel>();  // we need this for changing content on events
    JPanel updateField;

    String materialName;   // these are because of updating on click
    String materialLength;
    String materialWidth;
    String materialAmount;

    JLabel darkLabel;

    updateFrame()
    {

        // we are sorting results in myInventory



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



        //  we are creating panel for displaying content of our inventory


        allMaterials = new JPanel();

        allMaterials.setBounds(0,header.getHeight(),this.getWidth(),this.getHeight()-header.getHeight());
        allMaterials.setBackground(new Color(0x939597));
        //allMaterials.setLayout(new FlowLayout(FlowLayout.CENTER,30,30));
        allMaterials.setLayout(new ModifiedFlowLayout(FlowLayout.CENTER,30,30));
        this.add(allMaterials);

        // space which will be message

        space1 = new JPanel();
        space1.setPreferredSize(new Dimension(this.getWidth(),55));
        space1.setOpaque(true);
        space1.setBackground(new Color(0x939597));  // new Color(0x939597)
        space1.setLayout(new FlowLayout());  // to center later label with text

        allMaterials.add(space1);

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


        // field when we can update amount of material
        updateField = new JPanel();
        updateField.setPreferredSize(new Dimension(this.getWidth(),80));
        updateField.setOpaque(false);

        // back btn


        backBtn = new JButton();
        backBtn.setIcon(backImage);
        backBtn.setOpaque(false);
        backBtn.setBorder(border);
        backBtn.addMouseListener(this);


        updateField.add(backBtn);


        // field
        inputField = new JTextField();
        inputField.setPreferredSize(new Dimension(400,50));
        inputField.setText("Nowa ilość materiału");
        inputField.setBackground(Color.black);
        inputField.setCaretColor(new Color(0xccd45d));
        inputField.setForeground(new Color(0x99a12a));
        inputField.setHorizontalAlignment(JTextField.CENTER);
        inputField.setBorder(border);
        inputField.addMouseListener(this);
        updateField.add(inputField);

        allMaterials.add(updateField);

        // submit button for field

        ImageIcon acceptImage = new ImageIcon("akceptuj.png");

        acceptBtn = new JButton();
        acceptBtn.setIcon(acceptImage);
        acceptBtn.setOpaque(false);
        acceptBtn.setBorder(border);
        acceptBtn.addMouseListener(this);


        updateField.add(acceptBtn);
        updateField.setVisible(false);

        ImageIcon removeMatImage = new ImageIcon("updateMaterial.png");

        for(int i=0;i<Main.myInventory.getHowManyMaterials();++i)
        {
            String materialDesc = "<html>" + Main.myInventory.getMaterialFromIndex(i).getName() + "<br/>Ilość: " +  Integer.toString(Main.myInventory.getMaterialFromIndex(i).getAmount()) + "<br/>Długość: " + Double.toString(Main.myInventory.getMaterialFromIndex(i).getLength()) + "<br/>Szerokość: " + Double.toString(Main.myInventory.getMaterialFromIndex(i).getWidth()) + "</html>";
            JLabel materialLabel = new JLabel();
            materialLabel.setPreferredSize(new Dimension(250,100));
            materialLabel.setHorizontalAlignment(JLabel.CENTER);
            materialLabel.setVerticalAlignment(JLabel.CENTER);
            materialLabel.setBackground(new Color(0xccd45d));
            materialLabel.setForeground(Color.black);
            materialLabel.setOpaque(true);
            materialLabel.setBorder(BorderFactory.createEtchedBorder());
            materialLabel.setText(materialDesc);
            materialLabel.setIcon(removeMatImage);
            materialLabel.setIconTextGap(10);
            materialLabel.addMouseListener(this);
            allMaterials.add(materialLabel);
            fields.add(materialLabel);
        }


        // adding scroll bar for our panel
        JScrollPane scrollPane = new JScrollPane(allMaterials);
        scrollPane.setHorizontalScrollBarPolicy(JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
        scrollPane.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED);
        scrollPane.setBounds(0, header.getHeight(), allMaterials.getWidth(), allMaterials.getHeight());
        //JPanel contentPane = new JPanel(null);
        //contentPane.setPreferredSize(new Dimension(500, 400));
        //contentPane.add(scrollPane);
        this.getContentPane().add(scrollPane);

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

        if(e.getSource() == backBtn)
        {
            updateField.setVisible(false);
            darkLabel.setBackground(new Color(0xccd45d));

            for(JLabel l : fields)
            {
                l.addMouseListener(this);
            }

        }


        if(e.getSource() == acceptBtn)
        {
            String userInput = inputField.getText();
            if(userInput.matches("\\d+"))  // we have appropirate number (int)
            {
                if(Integer.parseInt(userInput) != Integer.parseInt(materialAmount)) {
                    System.out.println(userInput + " " + materialName + " " + materialLength + " " + materialWidth);

                    // now we have to update values in our Myinventory

                    Main.myInventory.changeAmountOfMaterial(materialName, Float.parseFloat(materialWidth), Float.parseFloat(materialLength), Integer.parseInt(userInput)); // update info

                    // now we change color of dark label

                    darkLabel.setBackground(new Color(0xccd45d));


                    // now we have to update our labels on the screen and reback Mouselisteners for labels

                    for (int i = 0; i < Main.myInventory.getHowManyMaterials(); ++i) {

                        String materialDesc = "<html>" + Main.myInventory.getMaterialFromIndex(i).getName() + "<br/>Ilość: " + Integer.toString(Main.myInventory.getMaterialFromIndex(i).getAmount()) + "<br/>Długość: " + Double.toString(Main.myInventory.getMaterialFromIndex(i).getLength()) + "<br/>Szerokość: " + Double.toString(Main.myInventory.getMaterialFromIndex(i).getWidth()) + "</html>";
                        fields.get(i).setText(materialDesc);
                        fields.get(i).addMouseListener(this);

                    }


                    message.setText("Pomyślnie zaaktualizowano materiał!");


                    message.setVisible(true);
                    // we want to hide our message after some delay
                    CompletableFuture.delayedExecutor(1, TimeUnit.SECONDS).execute(() -> {
                        message.setVisible(false);
                    });


                    // set default inputfield text

                    inputField.setText("Nowa ilość materiału");


                    // we close our updating panel because we updated material

                    updateField.setVisible(false);
                }
                else
                {
                    message.setText("Zmieniona wartość jest taka sama");
                    message.setVisible(true);

                    // we want to hide our message after some delay
                    CompletableFuture.delayedExecutor(1, TimeUnit.SECONDS).execute(() -> {
                        message.setVisible(false);
                    });
                }
            }
            else
            {
                message.setText("Niepoprawna wartość!");
                message.setVisible(true);

                // we want to hide our message after some delay
                CompletableFuture.delayedExecutor(1, TimeUnit.SECONDS).execute(() -> {
                    message.setVisible(false);
                });

            }
        }


        if(e.getSource() instanceof JLabel)   // we only react on this JLabel which have declared addMouseListener!!  (useful)
        {
            //System.out.println(((JLabel) e.getSource()).getText());
            //String substringName = ((JLabel) e.getSource()).getText().substring(6,((JLabel) e.getSource()).getText().indexOf("<br/>"));
            //System.out.println(substringName);

            // we remove add listeners from every labels (fields)


            for(JLabel l : fields)
            {
                l.removeMouseListener(this);
            }

            // we display panel for input new amount

            updateField.setVisible(true);

            String[] parts = ((JLabel) e.getSource()).getText().split("<br/>");
            materialName = parts[0].substring(6);
            materialAmount = parts[1].substring(7);
            materialLength = parts[2].substring(9);
            materialWidth = parts[3].substring(11,parts[3].indexOf("</html>"));

            // dark background on particular label
            ((JLabel) e.getSource()).setBackground(new Color(0xaab23b));
            darkLabel = (JLabel) e.getSource();   // we need to change it later



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
        if(e.getSource() instanceof  JLabel)
        {
            ((JLabel) e.getSource()).setBackground(new Color(0xaab23b));
        }
        if(e.getSource() == acceptBtn)
        {
            acceptBtn.setBorder( new LineBorder(new Color(0x333333), 4, true));
        }
        if(e.getSource() == backBtn)
        {
            backBtn.setBorder( new LineBorder(new Color(0x333333), 4, true));
        }
    }

    @Override
    public void mouseExited(MouseEvent e) {
        if(e.getSource() instanceof javax.swing.JButton ){((JButton) e.getSource()).setBackground(new Color(0xccd45d));}
        if(e.getSource() instanceof  JLabel)
        {
            ((JLabel) e.getSource()).setBackground(new Color(0xccd45d));
        }
        if(e.getSource() == acceptBtn )
        {
            acceptBtn.setBorder(border);
        }
        if(e.getSource() == backBtn)
        {
            backBtn.setBorder( border);
        }

    }

}
