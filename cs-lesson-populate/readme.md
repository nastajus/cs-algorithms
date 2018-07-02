### populate lessons

Journal:

So yesterday I got stuck.  I was attempting to apply deserialization data to a pre-initialized object, as instructed, to familiarize myself with a specific tech stack, including { Newsoft's JSON.NET, and RestSharp }. I had several gripes when I got stuck on my own, before help arrived:  

1. firstly: both my calls to `JsonConvert.PopulateObject` (1st) and `JsonConvert.DeserializeAnonymousType` (2nd) "failed"
    - _(in hindsight for unknown "magical" reasons, my brain allowed itself to think.)_
1. secondly: when browsing JsonConvert's API with VS' ~~object browser~~ .. with VS' **go to definition**, i didn't appreciate the _mutable nature of parameter objects_ being passed in for one method (1st), and i didn't pay attention to _the return type T_ in another method (2nd)
    - _(hidden to me since ~~being a generic return...~~  being an unfamiliar return WITH being uncomfortable with complexity)._
1. thirdly: stumbling on **object browser** (in false hope expectation matching hierachy ~browsers), though I'd say it's a "win" that I explored VS' equivalents and ReSharpers equivalents...... such as...
1. fourthly: simple lack of C# fundamentals caused difficulty using the "small time" library of RestSharp. Previous company tech stack was all quite popular.
    - (I could more often _rely on others replies in StackOverflow I found through Google_ for issues I'd have using Tomcat, Apache Commons, Java itself...)


### Personal Lessons for Learning:
- become the a rockstar developer.
- be comfortable with complexity.
- be curious until sated not interrupted.
- build my internally consistent system of knowledge.
    - -->> **"If I cannot code it, I do not understand it."**
- work on specific known areas to improve.
- use more than mere keyword identifiers of topics, use sets of selected sentences to describe the system comprising that keyword.
- beware slips in accuracy of language.


### Specific improvables:
specific known areas to improve:
- generics.
    - What Do They Know? Do They Know Things?? Let's Find Out!
    - A
    - "determined at runtime"
    - B
    - generic type parameters are conventially declared with a single letter, like T, in a method signature. AND, when invoked any type is an acceptable argument, like Dog, Doberman, Person. ~~(originally wrote: acceptable to be passed in)~~ -- sounds accurate, finally : 8 iterations, maybe 1 hour.
    - C
    - what's the purpose of generics?
        - well, < generalized "input" >, and by input I mean: { passing argument into a method }.
        - so what?
        - ...
    - this might need several passes to refine.
- types
    - compare these `thing.GetType()` vs `typeof(Thing)`
        1. first: << "operates on" >> an "instance object", examining it, returning an "meta object" comprised of << the type of thing instance object >>
        1. second:

    - examples to freshen mind
        - `int x = 3` -- what's the type of variable x?
            - the type is Int32
        - `Foo f = new Foo()` -- what's the type of variable f?
            - the type is Foo.

- reflection
    - all things reflection work exclusively with the compile-time types, and have always have zero info about any instance objects. Interesting.
    -

### definitions

- **ar-gu-ment** -- from arguere "make clear, make known, prove"
- **pa-ra-me-ter** -- para- "beside",  me- "to measure".  ... "boundary, limit, characteristic factor" ...

- imperative -- specially ordered, to command, make ready
- declare -- thoroughly, make clear, explain, elucidate, reveal, disclose, announce


### visual studio terms
- **locals** - personally upset at A) complexity B) aesthetic
- **DataTips** - personally upset at A) usability


### replaying backwards

nice contrast for me:
```
    public static T DeserializeAnonymousType<T>(string value, T anonymousTypeObject);
    public static object DeserializeObject(string value);
```

quick test library calls provided are not updatable:

```
    var testStr = "{\"test\":\"thing\"}";

    var testObj = new {test = ""};

    JsonConvert.PopulateObject(testStr, testObj);
    var resobj = JsonConvert.DeserializeAnonymousType(testStr, testObj)
```


a derpful moment, i'd mixed up pType and p.

```
        static void SetNameOfThing(object p, string name)
        {
            Type pType = p.GetType();
            if (pType.Name == typeof(Dog).Name || pType.Name == typeof(Person).Name)
            {
                //remember the ... doesn't have any info on the instance itself, despite ... coming from instance
                pType.GetField("name").SetValue(pType, name);
            }  //System.ArgumentException: 'Field 'name' defined on type 'cs_sl.Program+Person' is not a field on the target object which is of type 'System.RuntimeType'.'
        }
```
- i caused an interesting error here... as if i was expecting


string comparison

```
pType.Name == typeof(Dog).ToString()
```


the goal here was to write `SetNameOfThing` _generally_ to accept either type `Dog`, `Person` or whatever.

```
    main...
    {
        var dante = new Person();


        var lassie = new Dog();
        SetNameOfThing(dante, "Dnate");
        SetNameOfThing(lassie, "Lassie");


        DmlPopulate(str,dante);
    }

    static void SetNameOfThing(object p, string name)
    {

    }
```



### Culmination lessons:

- **types** - Represents type ~~declarations~~: class types, interface types, array types, value types, enumeration types, _type parameters, generic type definitions, and open or closed constructed generic types._

- **fields** - A field is a variable of any type that is declared directly in a class or struct. Fields are members of their containing type.

- instanceOfType.GetType() vs. typeof(type)




##### GetType
```
...object p...
Type pType = p.GetType();
```
- returns a "meta type object", based purely on examining an `instance type object`, which is **rich** with great informtion about that type, like so: _"sl_cs.Program.Person.website; Type:string, ByteAlignment:2; Flags:Instace|public"_, but has nothing of the object itself.
- this was a gift, a present, this returned instance variable. there is a joy in exploring it, if i allow it.


##### GetField

```
pType.GetField("name")
```
- returns a **FieldInfo instance object**

Anonymous Type pre-initialized to sensible default values
```
var rateLimit3 = new
{
    rate = new {limit = 0, remaining = 0, reset = 0},
    resources = new
    {
        core = new {limit = 0, remaining = 0, reset = 0},
        search = new {limit = 0, remaining = 0, reset = 0}
    }
};
```

##### absent expected implicit parameter (in my mind...)

```
pType.GetField("name").SetValue(pType, name);
```

- this code is upsetting, due to the repetition of `pType`. i _would argue it **should** be written such that_ `pType` need not be repeated. How might that code appear?
- well, probably like so: << (1st) `pType.GetField("name")` >> . << (2nd) `SetValue(name);` >>
- well, let's examine the possibility. what is the return type of 1st and 2nd?
    - 0th: object -- _... well, originally `object` is the compiled type parameter, but ..._
    - 1st: FieldInfo.
    - 2nd: void
- therein lies my issue. I expected a return type conducive to chaining, without verifying assumptions.



Library usages.

```
JsonConvert.PopulateObject(response.Content, rateLimit3);
JsonConvert.DeserializeAnonymousType(response.Content, rateLimit3);
```

### Gotchas

- the scale of complexity, i wasn't prepared for
    - while browsing variable state while debugging, either by local pane or datatips hover popup region.
- "get rid of console window"
    - _it was bothering me popping up everytime i ran my code, if only interrupting my "flow" by blocking sight of the code i was just debugging..._
    - change project properties from console to windows. ...

    - Attempted -- Without Console window, Console.WriteLine works like Trace.WriteLine [link](https://stackoverflow.com/questions/2518509/redirect-console-write-methods-to-visual-studios-output-window-while-debuggi)



### Later review content:

##### populate concepts:

Concepts
- https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/

Definitions:
- https://msdn.microsoft.com/en-us/library/system.type(v=vs.110).aspx
- https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables
- https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields

Terms:
- ~~implicit variable~~
- [implicit parameter](http://www.mathcs.emory.edu/~cheung/Courses/170.2010/Syllabus/03/implicit-param.html)

##### my own explorations (unrelated to populate):

Concepts
- https://stackoverflow.com/questions/507747/can-you-explain-the-concept-of-streams

Visual Studio concepts:
- https://docs.microsoft.com/en-us/visualstudio/debugger/view-data-values-in-data-tips-in-the-code-editor
- [hidden gems](https://blogs.msdn.microsoft.com/visualstudio/2017/10/05/7-hidden-gems-in-visual-studio-2017/)
- "Output" Tab (View -> Output, or Ctrl+Alt+O)

Terms
- managed code
- [code snippets](https://msdn.microsoft.com/en-us/library/ms165392.aspx), eg insertion snippet or as a surround-with snippet

##### other concepts recently discussed, but unrelated:

- strings are immutable objects.
    - the way they're implemented prevents mutation............................ to think more about.
