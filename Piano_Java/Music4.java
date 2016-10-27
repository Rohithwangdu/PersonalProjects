
import java.awt.*;
import java.applet.*;
import java.awt.event.*;
import java.awt.Image;
import javax.swing.*;
public class Music4 extends JApplet  implements KeyListener
{
     	String tune[]=new String[20]; 
     	ImageIcon[] MyImage = new ImageIcon[14]; 
    	Button b,b2,b3; 
     	int i= 0; 
     	AudioClip clip[]=new AudioClip[25]; 
     	int len;
     	String str1,en;
     	char msg;
     	TextField txtField,tt,ttfield;
   	 String mstxt=new String();

     	public void init()
	{	setBackground(Color.black);
          		setSize(2000,1000); 
           		tune[0]="a.wav";
           		tune[1]="s.wav";
            		tune[2]="d.wav";
            		tune[3]="f.wav";
            		tune[4]="j.wav";
            		tune[5]="k.wav";
            		tune[6]="l.wav";
            		tune[7]="h.wav";
            		tune[8]="w.wav";
            		tune[9]="e.wav";
            		tune[10]="i.wav";
            		tune[11]="o.wav";
            		tune[12]="p.wav";
		setBackground(Color.black);
 		setLayout(new FlowLayout());
		setBackground(Color.black);	
	 	str1="";
		MyImage[0]=new ImageIcon(getClass().getResource("piano6.jpg"));
		MyImage[0]=new ImageIcon(getClass().getResource("piano_a.jpg"));
		MyImage[1]=new ImageIcon(getClass().getResource("piano_s.jpg"));
		MyImage[2]=new ImageIcon(getClass().getResource("piano_d.jpg"));
		MyImage[3]=new ImageIcon(getClass().getResource("piano_f.jpg"));
		MyImage[4]=new ImageIcon(getClass().getResource("piano_j.jpg"));
		MyImage[5]=new ImageIcon(getClass().getResource("piano_k.jpg"));
		MyImage[6]=new ImageIcon(getClass().getResource("piano_l.jpg"));
		MyImage[7]=new ImageIcon(getClass().getResource("piano_;.jpg"));
		MyImage[8]=new ImageIcon(getClass().getResource("piano_w.jpg"));
		MyImage[9]=new ImageIcon(getClass().getResource("piano_e.jpg"));
		MyImage[10]=new ImageIcon(getClass().getResource("piano_I.jpg"));
		MyImage[11]=new ImageIcon(getClass().getResource("piano_o.jpg"));
		MyImage[12]=new ImageIcon(getClass().getResource("piano_o.jpg"));

       		for(i=0;i<13;i++)
	 		clip[i]=getAudioClip(getCodeBase(),tune[i]);
       		
		addKeyListener(this);
       		ActionListener a = new MyActionListener();
		tt=new TextField(20);
		txtField = new TextField(20);
    		txtField.addKeyListener(this);
    		add(txtField, BorderLayout.NORTH);
		b3=new Button("edit");
		add(b3);
     		b3.setActionCommand("edit");
		b3.addActionListener(a); 

		add(tt, BorderLayout.SOUTH);
		setBackground(Color.black);
		
		b=new Button("postRecord");
    		add(b);
		b.setActionCommand("postRecord");
		b.addActionListener(a);
		b2=new Button("play");
		add(b2);
		b2.setActionCommand("play");
		b2.addActionListener(a); 
                                    		
	}
	class MyActionListener implements ActionListener 
	{ 
  	         public void actionPerformed(ActionEvent ae)
 	        {
	
    		String s = ae.getActionCommand(); 
    		if (s.equals("postRecord"))
		{ 
			mstxt=txtField.getText();
			str1=s;
			repaint();
		}
	
  		if(s.equals("play")) 
		{
			len=mstxt.length();
			repaint();
        		for(int j=0;j<len;j++)
        		{
		   	if(mstxt.charAt(j)=='a')
			//for(int k=0;k<35000000;k++)
            			{clip[0].play();i=0;}
			for(int k=0;k<2000000;k++)
            			if(mstxt.charAt(j)=='s')
             			{clip[1].play();i=1;}
            		
                 			if(mstxt.charAt(j)=='d')
			for(int k=0;k<35000000;k++);
                 			{clip[2].play();i=2;}
            		for(int k=0;k<35000000;k++);        
                 			if(mstxt.charAt(j)=='f')
                 			{clip[3].play();i=3;}
		for(int k=0;k<35000000;k++);
         			if(mstxt.charAt(j)=='j')
             			{clip[4].play();i=4;}
		for(int k=0;k<35000000;k++);     
    			if(mstxt.charAt(j)=='k')
             			{clip[5].play();i=5;}
		for(int k=0;k<35000000;k++);
        			if(mstxt.charAt(j)=='l')
             			{clip[6].play();i=6;}
		for(int k=0;k<35000000;k++);      
  			if(mstxt.charAt(j)==';')
             			{clip[7].play();i=7;}
		for(int k=0;k<35000000;k++);
         			if(mstxt.charAt(j)=='w')
             			{clip[8].play();i=8;}
		for(int k=0;k<35000000;k++);
        			if(mstxt.charAt(j)=='e')
             			{clip[9].play();i=9;}
		for(int k=0;k<35000000;k++);      
   			if(mstxt.charAt(j)=='i')
             			{clip[10].play();i=10;}
		for(int k=0;k<35000000;k++);
        			if(mstxt.charAt(j)=='o')
             			{clip[11].play();i=11;}
		for(int k=0;k<35000000;k++);    
    			if(mstxt.charAt(j)=='p')
             			{clip[12].play();i=12;}

	}repaint();
   }

}
}
    



public void keyPressed(KeyEvent ke)
    {
           
	    if(str1.equals("record"))
          	   {
    		 char c = ke.getKeyChar();
             		String str = Character.toString(c);              
          	   }
        
     }
     public void keyReleased(KeyEvent ke)
     {

     }


    public void keyTyped(KeyEvent ke)
    {
        
        msg =ke.getKeyChar();
        if(ke.getKeyChar()=='a')
           { clip[0].play();i=0;}
        else if(ke.getKeyChar()=='s')
            { clip[1].play();i=1;}

        else if(ke.getKeyChar()=='d')
             {clip[2].play();i=2;}
        else if(ke.getKeyChar()=='f')
             {clip[3].play();i=3;}

        else if(ke.getKeyChar()=='j')
             {clip[4].play();i=4;}
        else if(ke.getKeyChar()=='k')
             {clip[5].play();i=5;}

        else if(ke.getKeyChar()=='l')
             {clip[6].play();i=6;}
        else if(ke.getKeyChar()==';')
             {clip[7].play();i=7;}
        else if(ke.getKeyChar()=='w')
             {clip[8].play();i=8;}

        else if(ke.getKeyChar()=='e')
             {clip[9].play();i=9;}
        else if(ke.getKeyChar()=='i')
             {clip[10].play();i=10;}

        else if(ke.getKeyChar()=='o')
             {clip[11].play();i=11;}
        else if(ke.getKeyChar()=='p')
             {clip[12].play();i=12;}

        else
        {

        }
  	repaint();
     }

    
   public void paint(Graphics g)
   {  
      	MyImage[i].paintIcon(this, g,0, 0);
	tt.setText(mstxt);
   }
   
}

/*<applet code="Music4" width=1500 height=400>
</applet>*/    