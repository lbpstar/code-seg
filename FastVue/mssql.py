from dbutils.pooled_db import PooledDB
import pymssql

class MSSQL(object):
    @staticmethod
    def connect():
        try:
            pool = PooledDB(creator=pymssql,mincached=2, maxcached=5,maxshared=3, maxconnections=6, blocking=True, host="192.168.0.176",port=1433,user="SMTCost", password="hytera2017cost",database= "BIDB",charset='utf8')
            conn = pool.connection()
            cursor = conn.cursor(as_dict=True)
            return conn,cursor
        except:
            raise (NameError,"连接数据库失败")
    @staticmethod
    def connect_close(conn,cursor):
        cursor.close()
        conn.close()
    @staticmethod
    def execquery(sql,paramtup):
        try:
            conn,cursor = MSSQL.connect()
            cursor.execute(sql,paramtup)
            resList = cursor.fetchall()
        except Exception:
            resList = ()
        MSSQL.connect_close(conn,cursor)
        return resList
    @staticmethod
    def execquery2(sql):
        try:
            conn,cursor = MSSQL.connect()
            cursor.execute(sql)
            resList = cursor.fetchall()
        except Exception:
            resList = ()
        MSSQL.connect_close(conn,cursor)
        return resList
    @staticmethod
    def execnonquery(sql,paramtup):
        try:
            conn,cursor = MSSQL.connect()
            cursor.execute(sql,paramtup)
            conn.commit()
        except Exception as e:
            print(e)
            conn.rollback() 
        MSSQL.connect_close(conn,cursor)
    @staticmethod
    def execnonquery2(sql):
        try:
            conn,cursor = MSSQL.connect()
            cursor.execute(sql)
            conn.commit()
        except Exception as e:
            print(e)
            conn.rollback() 
        MSSQL.connect_close(conn,cursor)

    @staticmethod
    def execproc(procname,paramtup):
        try:
             conn,cursor = MSSQL.connect()
             cursor.callproc(procname,paramtup)
             cursor.nextset()
             result = cursor.fetchall()
             conn.commit()
        except Exception:
            conn.rollback() 
            result = ()
        MSSQL.connect_close(conn,cursor)
        return result
