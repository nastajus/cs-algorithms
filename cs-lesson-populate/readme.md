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


### Lessons
- become the a rockstar developer.
- be comfortable with complexity.
- be curious until sated not interrupted.
- build my internally consistent system of knowledge. 
    - -->> **"If I cannot code it, I do not understand it."**
- work on specific known areas to improve.
- use more than mere keyword identifiers of topics, use sets of selected sentences to describe the system comprising that keyword.
- beware slips in accuracy of language. 


### Specific improvements:
specific known areas to improve:
- generics.
    - What Do They Know? Do They Know Things?? Let's Find Out!
    - A
    - "determined at runtime" 
    - "the type(?) is determined at runtime" - fragment
    - ~~"generic types accept umm anything?"~~
    - generic types accept any _polymorphic type_. -- _fragment_
    - generic type parameters accept any argument in an inhertiance hierarhcy. -- _not true... misleading..._
    - generic type parameters are conventially declared with a single letter, like T, in a method signature. AND, when invoked any type is an acceptable argument, like Dog, Doberman, Person. ~~(originally wrote: acceptable to be passed in)~~ -- sounds accurate, finally : 8 iterations, maybe 1 hour. 






- definitions necessary:    
    - **ar-gu-ment** -- from arguere "make clear, make known, prove"
    - **pa-ra-me-ter** -- para- "beside",  me- "to measure".  ... "boundary, limit, characteristic factor" ... 

    - imperative -- specially ordered, to command, make ready
    - declare -- thoroughly, make clear, explain, elucidate, reveal, disclose, announce










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

Library usages.

```
JsonConvert.PopulateObject(response.Content, rateLimit3);
JsonConvert.DeserializeAnonymousType(response.Content, rateLimit3);
```


