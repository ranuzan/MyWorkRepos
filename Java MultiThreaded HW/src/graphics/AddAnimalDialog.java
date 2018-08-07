package graphics;

import java.awt.*;

import javax.swing.*;

import animals.Animal;

import java.awt.event.*;

public class AddAnimalDialog extends JDialog implements ItemListener, ActionListener {
	private static final long serialVersionUID = 1L;
	private JPanel p1,p2,p3,p4,p5,p6,p7,p8;
    private JButton ok, cancel;
    private JLabel lbl_sz, lbl_hor, lbl_ver;
    private JSlider sl_sz, sl_hor, sl_ver;
    private ButtonGroup rbg, rbg1;
    private String[] colors = {"Natural","Red","Blue"};
    private String[] animals ;
    private String chosenAnimal;
    private String c;
    private JRadioButton[] rb;
    private JRadioButton[] rb1;
    private ZooPanel ap;
    private String type;
    private OmnivoreFactory of;
    private CarnivoreFactory cf;
    private HerbivoreFactory hf;

 
    public AddAnimalDialog(ZooPanel pan, String title ,String[] animals1)
    {
    	super(new JFrame(),title,true);
    	this.animals = animals1;
    	type=title;
    	ap = pan;

    	setSize(550,300);
	
		setBackground(new Color(100,230,255));
		p1 = new JPanel();
		p2 = new JPanel();
		p3 = new JPanel();
		p4 = new JPanel();
		p5 = new JPanel();
		p6 = new JPanel();
		p7 = new JPanel();
		p8 = new JPanel();
	
		p1.setLayout(new GridLayout(2,3,10,0));
		lbl_sz = new JLabel("Size of animal",JLabel.CENTER);
		p1.add(lbl_sz);
		lbl_hor = new JLabel("Horizontal spead",JLabel.CENTER);
		p1.add(lbl_hor);
		lbl_ver = new JLabel("Vertical spead",JLabel.CENTER);
		p1.add(lbl_ver);
		
		sl_sz = new JSlider(50,300);
		sl_sz.setMajorTickSpacing(100);
		sl_sz.setMinorTickSpacing(10);
		sl_sz.setPaintTicks(true);
		sl_sz.setPaintLabels(true);
		p1.add(sl_sz);
		
		sl_hor = new JSlider(0,10);
		sl_hor.setMajorTickSpacing(2);
		sl_hor.setMinorTickSpacing(1);
		sl_hor.setPaintTicks(true);
		sl_hor.setPaintLabels(true);
		p1.add(sl_hor);
		
		sl_ver = new JSlider(0,10);
		sl_ver.setMajorTickSpacing(2);
		sl_ver.setMinorTickSpacing(1);
		sl_ver.setPaintTicks(true);
		sl_ver.setPaintLabels(true);
		p1.add(sl_ver);

		p2.setLayout(new GridLayout(3,1,0,0));
		p2.add(p6);
		p2.add(p7);
		p2.add(p8);
		p7.setLayout(new GridLayout(1,3,5,5));
		rbg = new ButtonGroup();
		rb=new JRadioButton[colors.length];


		p4.setLayout(new GridLayout(3,2,5,5));
		rbg1 = new ButtonGroup();
		rb1=new JRadioButton[animals.length];
		for(int i=0;i<animals.length;i++)
		{
		    rb1[i] = new JRadioButton(animals[i],false);
		    rb1[i].addItemListener(this);
		    rbg1.add(rb1[i]);
		    p4.add(rb1[i]);
		}
		
		rb1[0].setSelected(true);

		p3.setLayout(new GridLayout(1,2,5,5));
		ok=new JButton("OK");
		ok.addActionListener(this);
		ok.setBackground(Color.lightGray);
		p3.add(ok);		
		cancel=new JButton("Cancel");
		cancel.addActionListener(this);
		cancel.setBackground(Color.lightGray);
		p3.add(cancel);
		
		p5.setLayout(new GridLayout(1,2,10,10));
		p5.add(p4);
		p5.add(p2);

		
		p4.setBorder(BorderFactory.createTitledBorder("Choose an animal"));

		setLayout(new BorderLayout());
		add("North" , p1);
		add("Center", p5);
		add("South" , p3);
    }
    public void itemStateChanged(ItemEvent e)
    {
		
		for(int i=0;i<rb1.length;i++)
			if(rb1[i].isSelected())
		    {
				chosenAnimal = animals[i];
		    	break;
	        }
    }
    public void actionPerformed(ActionEvent e)
    {
    	Animal animal=null;
 		if(e.getSource() == ok)
		{
 			if(type.equals("omnivore")){
 				of=new OmnivoreFactory(sl_sz.getValue(),0,0,sl_hor.getValue(),sl_ver.getValue(),"Natrual", ap);
 				animal=of.produceAnimal(chosenAnimal);
 				ap.addAnimal(animal);
 			}
 			if(type.equals("carnivore")){
 				cf=new CarnivoreFactory(sl_sz.getValue(),0,0,sl_hor.getValue(),sl_ver.getValue(),"Natrual", ap);
 				animal=cf.produceAnimal(chosenAnimal);
 				ap.addAnimal(animal);
 			}
 			if(type.equals("herbivore")){
 				hf=new HerbivoreFactory(sl_sz.getValue(),0,0,sl_hor.getValue(),sl_ver.getValue(),"Natrual", ap);
 				animal=hf.produceAnimal(chosenAnimal);
 				ap.addAnimal(animal);
 			}	
		    setVisible(false);
		}
		else 
		    setVisible(false);
    }
}
