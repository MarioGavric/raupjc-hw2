#Pitanje 1: 
Izvodenje programa trajalo je 5.0044482 sekundi. 
#Pitanje 2: 
Na jednoj. 
#Pitanje 3: Izvodenje programa trajalo je 1.0552666 sekundi. 
#Pitanje 4: 
Na 5 dretvi. 
#Pitanje 5: 
Ako citamo istu vrijednost na vise dretvi, moze se desiti da se procita na njih ista vrijedonst (ne napravi se izmjena od poziva na npr. prvu dretvu), npr. ako imamo varijablu vrijednosti 0 i hocemo je povecat za 1 pri svakom pozivu, paralelnim pozivanjem na svakoj dretvi mozemo dobiti pocetnu vrijednost 0, te povecat na 1 i spremit 1 iz svih dretvi, a ocekivano je bilo 1 iz prvog poziva iz drugog pa 2 ... i tako ovisno o broju poziva. Zato korisitmo monitore i semafore