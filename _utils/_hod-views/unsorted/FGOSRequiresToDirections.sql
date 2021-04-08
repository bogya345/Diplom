
DROP VIEW FGOSRequiresToDirections

CREATE VIEW FGOSRequiresToDirections
AS

SELECT 
--top 100
	dirs.direct_id,
	
	fgos.fgos_id,
	fgos.fgos_num,

	dir_fgos.settedValue,
	units.unit_name,

	fgos.fgos_content

FROM hod.Import.Directions as dirs

	-- ��������� 1: ����������� - ���������� ����
	inner join hod.dbo.Direction_fgos as dir_fgos on dir_fgos.direct_id = dirs.direct_id

	-- ���������� ����
	inner join hod.dbo.fgos_requirs as fgos on fgos.fgos_id = dir_fgos.fgos_id

	-- �������
	inner join hod.dbo.Units as units on units.unit_id = dir_fgos.unit_id
