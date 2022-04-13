package hurtownia;

import hurtownia.Main;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.util.ArrayList;
import java.util.List;

public class displayFrame extends JFrame implements MouseListener, ActionListener {

    JButton backButton;
    JComboBox dropdownMenu;
    List<JLabel> fields = new ArrayList<JLabel>();  // we need this for changing content on events

    displayFrame()
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


        JPanel allMaterials = new JPanel();

        allMaterials.setBounds(0,header.getHeight(),this.getWidth(),this.getHeight()-header.getHeight());
        allMaterials.setBackground(new Color(0x939597));
        //allMaterials.setLayout(new FlowLayout(FlowLayout.CENTER,30,30));
        allMaterials.setLayout(new ModifiedFlowLayout(FlowLayout.CENTER,30,30));
        this.add(allMaterials);

        JPanel sortMenu = new JPanel();
        sortMenu.setPreferredSize(new Dimension(this.getWidth(),80));
        sortMenu.setOpaque(false);  // we want to have the same background color


        // we create dropdwon menu list

        String[] itemsOfMenu = {"Nazwa","Ilość","Długość","Szerokość"};
        dropdownMenu = new JComboBox(itemsOfMenu);
        dropdownMenu.addActionListener(this);

        sortMenu.add(dropdownMenu);
        allMaterials.add(sortMenu);


        for(int i=0;i<Main.myInventory.getHowManyMaterials();++i)
        {

            String materialDesc = "<html>" + Main.myInventory.getMaterialFromIndex(i).getName() + "<br/>Ilość: " +  Integer.toString(Main.myInventory.getMaterialFromIndex(i).getAmount()) + "<br/>Długość: " + Double.toString(Main.myInventory.getMaterialFromIndex(i).getLength()) + "<br/>Szerokość: " + Double.toString(Main.myInventory.getMaterialFromIndex(i).getWidth()) + "</html>";
            JLabel materialLabel = new JLabel();
            materialLabel.setPreferredSize(new Dimension(150,100));
            materialLabel.setHorizontalAlignment(JLabel.CENTER);
            materialLabel.setVerticalAlignment(JLabel.CENTER);
            materialLabel.setBackground(Color.black);
            materialLabel.setForeground(new Color(0xccd45d));
            materialLabel.setOpaque(true);
            materialLabel.setBorder(BorderFactory.createEtchedBorder());
            materialLabel.setText(materialDesc);
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

    @Override
    public void actionPerformed(ActionEvent e) {
        if(e.getSource() == dropdownMenu)
        {

            switch(dropdownMenu.getSelectedIndex())   // sorting our inventory by selected field
            {

                case 0:
                    Main.myInventory.sortInventory((Material p,Material n)->{

                        if(p == null || n == null){return 0;}
                        return p.getName().compareTo(n.getName());
                    });
                    break;

                case 1:

                    Main.myInventory.sortInventory((Material p,Material n)->{

                        if(p == null || n == null){return 0;}
                        return Integer.compare(p.getAmount(),n.getAmount())*(-1);
                    });

                    break;

                case 2:

                    Main.myInventory.sortInventory((Material p,Material n)->{

                        if(p == null || n == null){return 0;}
                        return Float.compare(p.getLength(),n.getLength());
                    });

                    break;

                case 3:

                    Main.myInventory.sortInventory((Material p,Material n)->{

                        if(p == null || n == null){return 0;}
                        return Float.compare(p.getWidth(),n.getWidth());
                    });

                    break;

            }

            // updating displayed content of fields  , we only update text of labels

            for(int i=0;i<Main.myInventory.getHowManyMaterials();++i)
            {

                String materialDesc = "<html>" + Main.myInventory.getMaterialFromIndex(i).getName() + "<br/>Ilość: " +  Integer.toString(Main.myInventory.getMaterialFromIndex(i).getAmount()) + "<br/>Długość: " + Double.toString(Main.myInventory.getMaterialFromIndex(i).getLength()) + "<br/>Szerokość: " + Double.toString(Main.myInventory.getMaterialFromIndex(i).getWidth()) + "</html>";
                fields.get(i).setText(materialDesc);

            }


        }
    }
}
