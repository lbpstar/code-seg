from fastapi import APIRouter
from mssql import MSSQL
from pydantic import BaseModel
from fastapi.security import OAuth2PasswordBearer

router = APIRouter()

class People(BaseModel):
    name: str
    age: int
    address: str
    salary: float
    
@router.post('/insert', tags=["qms"])
def insert(people: People):
    age_after_10_years = people.age + 10
    msg = f'此人名字叫做：{people.name}，十年后此人年龄：{age_after_10_years}'
    return {'success': True, 'msg': msg}
