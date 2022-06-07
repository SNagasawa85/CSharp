Buffet buffet = new Buffet();

SweetTooth sweet = new SweetTooth("Frank");
SpiceHound spicey = new SpiceHound("Tim");


while(sweet.IsFull == false){
    sweet.Consume(buffet.Serve());
}

while(spicey.IsFull == false){
    spicey.Consume(buffet.Serve());
}
