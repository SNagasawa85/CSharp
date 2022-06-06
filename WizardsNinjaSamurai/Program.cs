Human newTarget = new Human("frank", 20,20,20,2000);
Human newHuman = new Human ("Jason");
Ninja newNinja =  new Ninja("nick");
Wizard newWizard = new Wizard("John");
Samurai newSamurai = new Samurai("Why");

newHuman.Attack(newTarget);
newNinja.Attack(newTarget);
newWizard.Attack(newTarget);
newSamurai.Meditate();
newSamurai.Attack(newTarget);
newNinja.Steal(newTarget);



