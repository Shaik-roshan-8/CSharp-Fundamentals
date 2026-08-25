What i learned day01 : 

What is il and why it exist ?

The il is the short form for intermediate language its an universal and independent cpu language means any cpu which is having .net runtime can read it . 
the il is the output from roslyn compiler which is also called as c sharp compiler , the il is stored inside the .dll file ( dynamic linked library ) oe exe file.
it exists because the human made code is converted into il with help of roslyn compiler or csc so that the other compiler can turn it into machine readable code .
learning from ai ( it exists because its portable( can run in any cpu after jits process ) and consistent ( same output across all cpus ) 

What the CLR does ?

the CLR is known as common language runtime it is an engine which consists of jit compiler , the clr manages memory through garbage collecter ( Reclaims unused memory )
and exception handling ( catching error without crashing full program ) and type system ( can not declare into to string variable ) ,
and CLR loads the assembly ( .dll or .exe ) into .net runtime and then the jit runtime compiles the code to machine readable ( native code ).

Why main is static ?

Main is static because we can call it before creating and object . static means we dont need any object to call and the details live inside the class not in object.

What a namespace solves ?

Namespace is like a folder where our methods , classes and types  live in so that we can call and use it and it is useful because the names
of types or methods doesnt clash,by use of derivative ( using )  we can use namespace items without mentioning
path again and again .
