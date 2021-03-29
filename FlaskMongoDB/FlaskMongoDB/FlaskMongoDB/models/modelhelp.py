from flask import Flask,jsonify
#from flask_sqlalchemy import SQLAlchemy
#from FlaskWebProject1 import db
#from sqlalchemy import DateTime,Numeric,Date,DECIMAL
import decimal,datetime

def _gen_tuple(self):
    def convert_datetime(value):
        if value:
            return value.strftime("%Y-%m-%d %H:%M:%S")
        else:
            return ""
    def convert_date(value):
        if value:
            return value.strftime("%Y-%m-%d")
        else:
            return ""

    for col in self.__table__.columns:
        if isinstance(col.type, DateTime):
            value = convert_datetime(getattr(self, col.name))
        elif isinstance(col.type, Date):
            value = convert_date(getattr(self, col.name))
        elif isinstance(col.type, Numeric):
            if getattr(self, col.name) == None: 
                value = None
            else:
                value = float(getattr(self, col.name))
        elif isinstance(col.type, DECIMAL):
            if getattr(self, col.name) == None: 
                value = None
            else:
                value = float(getattr(self, col.name))
        else:
            value = getattr(self, col.name)
        yield (col.name, value)

def to_dict(self):
    return dict(self._gen_tuple())

def to_json(self):
    #return json.dumps(self.to_dict())
    return jsonify(self.to_dict())


db.Model._gen_tuple = _gen_tuple
db.Model.to_dict = to_dict
db.Model.to_json = to_json

class ListToJson(object):
    @staticmethod
    def _gen_list(list):
        def convert_datetime(value):
            if value:
                return value.strftime("%Y-%m-%d %H:%M:%S")
            else:
                return ""
        def convert_date(value):
            if value:
                return value.strftime("%Y-%m-%d")
            else:
                return ""
        for l in list:
            for key,value in l.items():
                if isinstance(value, datetime.datetime):
                    #value = convert_datetime(value)
                    l[key] = convert_datetime(value)
                elif isinstance(value, datetime.date):
                    l[key] = convert_date(value)
                elif isinstance(value, decimal.Decimal):
                    if value == None: 
                        l[key] = None
                    else:
                        l[key] = float(value)
                else:
                    l[key] = value
                #yield (key, value)
        return list
    
