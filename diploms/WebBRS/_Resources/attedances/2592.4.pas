program funct1;

var
  z, a, x: real;

begin
  writeln('������� �������� a:');
  readln(a);
  writeln('������� �������� x:');
  readln(x);
  if ((9 - sqr(a)) >= 0)
    then 
    if ((x + sin(a)) <> 0)
    then
    begin
      z := (sqrt(9 - sqr(a)) / (x + sin(a)));
      writeln('�������� �������:', z:5);
    end
    else
      writeln('�������� "x+sin(a)" �� ������������� ���')
  else
    writeln('�������� "a" �� ������������� ���');
  
end.