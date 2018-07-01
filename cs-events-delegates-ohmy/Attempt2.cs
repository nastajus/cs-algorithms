using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_events_delegates_ohmy
{
    class Attempt2
    {
        // Why use event listeners over function calls?
        // https://stackoverflow.com/questions/4503723/why-use-event-listeners-over-function-calls

        // preventing sins of coupling --> ( ?? )
        // working around codebases i cannot change
        // making codebases that cannot be changed & have documentation when "raised"

        // why use events instead of directly calling functions
        // https://stackoverflow.com/questions/13588732/why-use-custom-events-instead-of-direct-method-calling

        // much easier unit tests
        // less chance of breaking code when changing class A or B
        // less references --> less risk of memory leaks
        // cleaner
        // more flexible code

        // Event model versus callbacks
        // https://help.adobe.com/en_US/as3/mobile/WS948100b6829bd5a6d20da321260fed8a52-8000.html

        // "object dispatching"
        // "loops through a list of listeners" 
        // "calls the event handler on each"
        // "registered object"

        // When should I use event-based programming?
        // https://softwareengineering.stackexchange.com/questions/267752/when-should-i-use-event-based-programming

        // "event dispatcher" == "handler function" == "subscriber"
        // "to wire handlers"
        // "to wire ███████████ to events"
        // "to wire handlers up to events"
        // "publish an event"
        // "publish an event to its subscribers"

        // Event-based programming is used when the program does not control the sequence of events that it performs. Instead, program flow is directed by an outside process such as a user (e.g. GUI), another system (e.g. client/server), or another process (e.g. RPC).

        // web servers, background processes also

        // In an Event-based application the concept of Event Listeners will give you the ability to write even more Loosely Coupled applications.

        // Loose Coupling
        // https://en.wikipedia.org/wiki/Loose_coupling



    }
}
