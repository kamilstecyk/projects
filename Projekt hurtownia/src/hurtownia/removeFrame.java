package hurtownia;

import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.border.LineBorder;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.TimeUnit;


public class removeFrame extends JFrame implements MouseListener {

    JButton backButton;
    JPanel space1;  // it will be message when button is clioked
    JLabel message;
    Border border = new LineBorder(Color.BLACK, 2, true);
    JPanel allMaterials;

    removeFrame()
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



        ImageIcon removeMatImage = new ImageIcon("usunMaterial.png");

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

        if(e.getSource() instanceof JLabel)   // we only react on this JLabel which have declared addMouseListener!!  (useful)
        {
            //System.out.println(((JLabel) e.getSource()).getText());
            //String substringName = ((JLabel) e.getSource()).getText().substring(6,((JLabel) e.getSource()).getText().indexOf("<br/>"));
            //System.out.println(substringName);

            String[] parts = ((JLabel) e.getSource()).getText().split("<br/>");
            String materialName = parts[0].substring(6);
            String materialLength = parts[2].substring(9);
            String materialWidth = parts[3].substring(11,parts[3].indexOf("</html>"));

            Main.myInventory.removeMaterial(materialName,Float.parseFloat(materialWidth),Float.parseFloat(materialLength));
            ((JLabel) e.getSource()).setVisible(false);
            message.setText("Pomyślnie usunięto materiał!");
            message.setVisible(true);


            // we want to hide our message after some delay
            CompletableFuture.delayedExecutor(1, TimeUnit.SECONDS).execute(() -> {
                message.setVisible(false);
            });


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
    }

    @Override
    public void mouseExited(MouseEvent e) {
        if(e.getSource() instanceof javax.swing.JButton ){((JButton) e.getSource()).setBackground(new Color(0xccd45d));}
        if(e.getSource() instanceof  JLabel)
        {
            ((JLabel) e.getSource()).setBackground(new Color(0xccd45d));
        }
    }


}
