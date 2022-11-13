import { Ubicacion } from "./ubicacion";

export interface Vivienda{
    id: string;
    propietario: string;
    localidad: string;
    provincia: string;
    ubicacion: Ubicacion;
    tipo: string;
    viviendaCompleta: boolean;
}
