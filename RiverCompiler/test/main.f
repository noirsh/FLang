mod sys;
mod io;

// run it as a test

gl func<CalcFullName>(string<name>, string<family>) -> string
{
	string<fullName> <- name + family;
	int<sum> <- 12 + 31;
	int<c> <- Inv::sum();
	// some comments in here
	out -> name + family;	
}

gl func<sum>() -> int
{
	out -> 12;
}

//these are comments with no spaces
// another with space

Inv::CalcFullName("ali", "alizade");
