using CallerArgumentExpression;

var array = new[] { 77, 568 };
    
// Debug.Assert(array.Length == 0, "array.Length == 0");
// CallerArgumentExpression is as performant as if you were to pass it by text yourself
// IL-vierwer misschien handig?

EnsureThat.ItIsNotEmpty(array);