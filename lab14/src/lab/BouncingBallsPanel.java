package lab;

import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class BouncingBallsPanel extends JPanel {

    static class Ball{
        int x;
        int y;
        double vx;
        double vy;
        Color color;
        static final int BALL_SIZE=10;

        public Ball(int x, int y, double vx, double vy, Color color) {
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
            this.color = color;
        }
    }

    List<Ball> balls = new ArrayList<>();

    class AnimationThread extends Thread {

        boolean suspend = true;
        int sleepTime = 50;

        synchronized void wakeup() {
            suspend = false;
            notify();
        }

        void safeSuspend() {
            suspend = true;
        }

        public void run() {
            for (; ; ) {
                //przesuń kulki
                //wykonaj odbicia od ściany
                //wywołaj repaint
                //uśpij

                synchronized (this) {
                    try {
                        if (suspend) {
                            System.out.println("suspending");
                            wait();
                        }
                    } catch (InterruptedException e) {
                    }
                }





                for (int i = 0; i < balls.size(); ++i) {

                    balls.get(i).x += balls.get(i).vx;
                    balls.get(i).y += balls.get(i).vy;

                    detectCollision(balls.get(i));
                    repaint();
                }


                try {
                    sleep(sleepTime);
                } catch (InterruptedException e) {
                }



            }
        }


        void detectCollision(Ball b)
        {
            // kolizje ze sciana

            Dimension d=getSize();
            if(b.x<Ball.BALL_SIZE){b.x=Ball.BALL_SIZE;b.vx*=-1;}
            if(b.x>d.width-Ball.BALL_SIZE){
            b.x=d.width-Ball.BALL_SIZE;b.vx*=-1;}
            if(b.y<Ball.BALL_SIZE){b.y=Ball.BALL_SIZE;b.vy*=-1;}
            if(b.y>d.height-Ball.BALL_SIZE){
                b.y=d.height-Ball.BALL_SIZE;b.vy*=-1;
            }



            // kolizje kulek ze soba

            for(int i=0;i<balls.size();++i)
            {
                for(int j=0;j<balls.size();++j)
                {
                    if(i != j)  // nie sprawdzamy kulki samej ze soba
                    {
                        double distance = Math.sqrt(Math.pow(balls.get(i).x - balls.get(j).x, 2) + Math.pow(balls.get(i).y - balls.get(j).y, 2));

                        if (distance <= Ball.BALL_SIZE){ // Jesli nachodza kulki na siebie, zmienimay kierunek
                            // akttualizujemy

                            balls.get(i).x -=  balls.get(i).vx;
                            balls.get(i).y -= balls.get(i).vy;
                            balls.get(j).x -= balls.get(j).vx;
                            balls.get(j).y -= balls.get(j).vy;
                            
                            balls.get(i).vx = -balls.get(i).vx ;
                            balls.get(i).vy = -balls.get(i).vy ;
                            balls.get(j).vx = -balls.get(j).vx ;
                            balls.get(j).vy = -balls.get(j).vy ;
                        }
                        
                    }
                }
            }


        }


        }
        




    AnimationThread aT;

    BouncingBallsPanel(){
        setBorder(BorderFactory.createStrokeBorder(new BasicStroke(3.0f)));

        // dodajemy poczatkowe pilki

        // losujemy w danym przedziale liczbe pilek
        int min = 10;
        int max = 22;

        int random_int = (int)Math.floor(Math.random()*(max-min+1)+min);


        int minV = -10;
        int maxV = 10;


        for(int i=0;i<random_int;++i) {

            // losowanie losowych parametrow

            // kolor

            Random rand = new Random();
            float r = rand.nextFloat();
            float g = rand.nextFloat();
            float b = rand.nextFloat();

            Color ballColor = new Color(r, g, b);

            // polozenie

            int ballX = rand.nextInt(600 - Ball.BALL_SIZE) + Ball.BALL_SIZE;
            int ballY = rand.nextInt(400 - Ball.BALL_SIZE)+150;

            // predkosci
            int randomIntVX = (int)Math.floor(Math.random()*(maxV-minV+1)+minV);
            int randomIntVY = (int)Math.floor(Math.random()*(maxV-minV+1)+minV);

            double vX = randomIntVX;
            double vY = randomIntVY;

            // tworzenie pilki i dodanie do listy

            Ball newBall = new Ball(ballX, ballY, vX, vY, ballColor);
            balls.add(newBall);
        }


        aT = new AnimationThread();
        aT.start();
        try {
            aT.wait();  // zatrzymujemy animacje dopoki nie zostanie wcisniety start
        }
        catch(Exception e)
        {
        }

    }

    public void paint(Graphics graph)
    {

        for(int i=0;i<balls.size();++i)
        {
            // rysujemy

            graph.setColor(balls.get(i).color);

            graph.fillOval( (int) balls.get(i).x-Ball.BALL_SIZE,
                    (int)balls.get(i).y-Ball.BALL_SIZE,
                    2*Ball.BALL_SIZE, 2*Ball.BALL_SIZE);
        }

    }


    long lastPaint=0;
    static final int frameRate=40;
    Image bufferImage=null;

    public void update(Graphics g) { if(System.currentTimeMillis()-lastPaint<frameRate)
        return;
        Dimension d=getSize();
        if(bufferImage==null || bufferImage.getHeight(this)!=d.height || bufferImage.getWidth(this)!=d.width)
        {
            bufferImage=createImage(d.width, d.height);
        }
        Graphics bufferGraphics=bufferImage.getGraphics();

        for(int i=0;i<balls.size();++i)
        {
            // rysujemy

            bufferGraphics.setColor(balls.get(i).color);

            bufferGraphics.fillOval( (int) balls.get(i).x-Ball.BALL_SIZE,
                    (int)balls.get(i).y-Ball.BALL_SIZE,
                    2*Ball.BALL_SIZE, 2*Ball.BALL_SIZE);
        }


        super.paint(bufferGraphics);
        g.drawImage(bufferImage, 0, 0, this);
        lastPaint=System.currentTimeMillis();
    }

    void onStart(){
        System.out.println("Start or resume animation thread");
        aT.wakeup();
    }

    void onStop(){
        System.out.println("Suspend animation thread");
        aT.safeSuspend();
    }

    void onPlus(){
        System.out.println("Add a ball");

        Random rand = new Random();
        float r = rand.nextFloat();
        float g = rand.nextFloat();
        float b = rand.nextFloat();

        Color ballColor = new Color(r, g, b);

        // polozenie

        int ballX = rand.nextInt(400 - Ball.BALL_SIZE) + Ball.BALL_SIZE;
        int ballY = rand.nextInt(400 - Ball.BALL_SIZE)+150;

        // predkosci

        int minV = -10;
        int maxV = 10;

        int randomIntVX = (int)Math.floor(Math.random()*(maxV-minV+1)+minV);
        int randomIntVY = (int)Math.floor(Math.random()*(maxV-minV+1)+minV);

        double vX = randomIntVX;
        double vY = randomIntVY;

        // tworzenie pilki i dodanie do listy

        Ball newBall = new Ball(ballX, ballY, vX, vY, ballColor);
        balls.add(newBall);

        repaint();

    }

    
    
    void onMinus(){
        System.out.println("Remove a ball");

        if(balls.size() >=1 ) {
            balls.remove(balls.size() - 1);

            repaint();
        }
    }
}
