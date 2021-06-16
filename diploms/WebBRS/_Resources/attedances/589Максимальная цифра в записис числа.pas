program maxzifra;

var
  n, max: integer;
  a: integer;

begin
  readln(a);
  max := a mod 10;
  a:= a mod 10;
  repeat
    n := (a mod 10);
    if n > max then
      max := n;
        writeln(max);
  until n = 0;
  writeln(max);
end.