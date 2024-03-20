import { DataGrid } from '@mui/x-data-grid';
import useRentalsTable from '../../hooks/useRentalsTable';
import EmptySet from '../../components/informational/EmptySet';

export default function RentalsTable() {
    const { rows, columns } = useRentalsTable();
    if (!rows || rows.length === 0) {
      return <EmptySet />;
    }

    return (
    <>
      <div style={{ height: '90vh', width: '100%' }}>
        <DataGrid
          
          rows={rows}
          columns={columns}
          initialState={{
            pagination: {
              paginationModel: { page: 0, pageSize: 5 },
            },
          }}
          pageSizeOptions={[5, 10, 20, 50, 100]}
        />
      </div>
    </>
    );
  }