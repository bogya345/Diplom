program coord;

var
  x, y, m: real;

begin
  writeln('¬ведите x:');
  readln(x);
  writeln('¬ведите y:');
  readln(y);
  if (x < 0) and (y < 0)
  then
  begin
    x := abs(x);
    y := abs(y);
  end
  else
  if (x < 0) xor (y < 0)
  then
  begin
    x := x + 0.5;
    y := y + 0.5;
  end
  else
  if (x > 0) and (y > 0)
  then
  begin
    x := x * 10;
    y := y * 10;
  end;
  writeln(x:5, y:5);
end.