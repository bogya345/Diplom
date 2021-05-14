import { DepsDto } from "./deps-models";

export {
    MapSubDepDto, 
    SubDepDto, SubDepModal,
    DepDepDto, DepDepModal
}

interface MapSubDepDto {
    subDeps: SubDepDto[],
    depDep: DepDepDto[],
    deps: DepsDto[]
}

interface SubDepDto {
    sub_id: number,
    sub_name: string,
    acPlDep_id: number,
    acPlDep_name: string,
    dep_id: number,
    dep_name: string,
}
interface SubDepModal {
    sub_id: number,
    acPlDep_id: number,
    dep_id: number
}

interface DepDepDto {
    acPlDep_id: number,
    acPlDep_name: string,
    dep_id: number,
    dep_name: string,
}
interface DepDepModal {
    acPlDep_id: number,
    dep_id: number
}