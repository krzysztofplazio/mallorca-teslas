import { GridColDef, GridValueFormatterParams } from "@mui/x-data-grid";
import { useEffect, useState } from "react";
import { RentalRow } from "../types/rentals";
import { getRentals } from "../api/axios";
import { Dayjs } from "dayjs";

export default function useRentalsTable() {
    const [ rows, setRows ] = useState<RentalRow[]>([]);
    const columns: readonly GridColDef[] = [
        { 
          field: 'id', 
          headerName: 'Id',
          width: 30,
        },
        { 
          field: 'totalPrice', 
          headerName: 'Total price', 
          width: 130,
          valueFormatter: (value: GridValueFormatterParams<number>) => {
            return `${value.value} €`
          },
        },
        { 
          field: 'from', 
          headerName: 'Borrow date', 
          width: 130,
          valueFormatter: (value: GridValueFormatterParams<Dayjs>) => {
            const date = value.value.toString().substring(0, 10);
            return date;
          },
        },
        { 
          field: 'to', 
          headerName: 'Return date', 
          width: 130,
          valueFormatter: (value: GridValueFormatterParams<Dayjs>) => {
            const date = value.value.toString().substring(0, 10);
            return date;
          },
        },
        {
          field: 'borrowPlace',
          headerName: 'Borrow Place',
          width: 250,
        },
        {
          field: 'returnPlace',
          headerName: 'Return Place',
          width: 350,
        },
        {
          field: 'car',
          headerName: 'Tesla',
        }
      ];

    useEffect(() => {
        const fetchRows = async () => {
            setRows(await getRentals());
        };

        fetchRows();
    }, []);
    return { rows, columns }
}