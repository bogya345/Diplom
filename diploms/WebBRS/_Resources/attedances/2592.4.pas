program funct1;

var
  z, a, x: real;

begin
  writeln('Введите значение a:');
  readln(a);
  writeln('Введите значение x:');
  readln(x);
  if ((9 - sqr(a)) >= 0)
    then 
    if ((x + sin(a)) <> 0)
    then
    begin
      z := (sqrt(9 - sqr(a)) / (x + sin(a)));
      writeln('Значение функции:', z:5);
    end
    else
      writeln('Значение "x+sin(a)" не удовлетворяет ОДЗ')
  else
    writeln('Значение "a" не удовлетворяет ОДЗ');
  
end.