stack and heap are two different areas of memory . 

the value types vs reference type : 
value types actually stores data 
reference types store address to the data , the data is stored somewhere esle .


the valuetypes data is stored in stack and when we have to use in method it takes a copy of that data and then original stays uneffected.
the reference data is stored in heap and when we use in method we are giving address to method it points to same object , the changes effect original .

in stack we store local variables data and adresses and method parametres and value types data its fast , cleaned automatically
in heap we can store objects and every object have address and adress is stored in stack , heap is large , flexible and cleaned by garbage collector .



differences between valuetypes and reference types : 
stores data and stores reference
lives in stack and lives in heap
nullable with int ? and reference type can be nullable
if we pass into method it copies , but reference type it effects original ( pointing to same object )


Note : valuetypes data can live inside its owner so it can live inside class i.e can live inside heap too.








