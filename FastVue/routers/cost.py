from fastapi import APIRouter
from mssql import MSSQL

router = APIRouter()

@router.get('/costgetdept/{saletype}', tags=["cost"])
def query(saletype: str):
    result = MSSQL.execproc("BI_COST_GET_DEPT",(saletype,))
    return result

