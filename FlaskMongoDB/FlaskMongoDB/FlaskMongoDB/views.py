"""
Routes and views for the flask application.
"""
from datetime import datetime
from flask import render_template
from FlaskMongoDB import app
import pymongo
from FlaskMongoDB.forms import MongoForm
from flask import request


@app.route('/')
@app.route('/home')
def home():
    """Renders the home page."""
    return render_template(
        'index.html',
        title='Home Page',
        year=datetime.now().year,
    )

@app.route('/contact')
def contact():
    """Renders the contact page."""
    return render_template(
        'contact.html',
        title='Contact',
        year=datetime.now().year,
        message='Your contact page.'
    )

@app.route('/about')
def about():
    """Renders the about page."""
    return render_template(
        'about.html',
        title='About',
        year=datetime.now().year,
        message='Your application description page.'
    )

@app.route('/mongo',methods=('GET', 'POST'))
def mongo():
    """mongo test."""
    #myclient = pymongo.MongoClient('mongodb://localhost:27017/')
    #dblist = myclient.list_database_names()
    ## dblist = myclient.database_names() 
    #if "test_db1" in dblist:
    #    msg = "test_db数据库已存在！"
    #else :
    #    msg = "test_db1数据库不存在！"

    #return render_template(
    #    'mongo.html',
    #    title='Mongo',
    #    year=datetime.now().year,
    #    message = msg
    #)
    mongo_form = MongoForm()
    if mongo_form.validate_on_submit():
        client = pymongo.MongoClient('mongodb://localhost:27017/')
        db = client["test_db"]
        collection = db["c_lbp"]
        data = {
                    'name':mongo_form.name.data
               }
        result = collection.insert_one(data) 
        print(result)
        # dblist = myclient.database_names() 
        if result.inserted_id is not None:
            msg = "数据插入成功"
        else :
            msg = "数据插入失败"

        return render_template(
            'mongo.html',
            title='Mongoadd',
            year=datetime.now().year,
            message = msg,
            mongo_form=mongo_form
        )
    #else :
    return render_template("mongo.html",mongo_form=mongo_form)

@app.route('/mongoadd')
def add():
    """mongo test."""
    client = pymongo.MongoClient('mongodb://localhost:27017/')
    db = client["test_db"]
    collection = db["c_lbp"]
    student = {
    'id': '20210122',
    'name': 'Jordan',
    'age': 20,
    'gender': 'male'
    }
    result = collection.insert_one(student) 
    print(result)
    # dblist = myclient.database_names() 
    if result.inserted_id is not None:
        msg = "数据插入成功"
    else :
        msg = "数据插入失败"

    return render_template(
        'mongo.html',
        title='Mongoadd',
        year=datetime.now().year,
        message = msg
    )
    
@app.route('/mongo_query')
def query():
    """mongo test."""
    client = pymongo.MongoClient('mongodb://localhost:27017/')
    db = client["test_db"]
    collection = db["c_test"]
    query = { "name": "baoping" }
    doc = collection.find(query)#doc是游标，所以需要知道游标有哪些操作和方法
    for x in doc:
        print(x)
    # dblist = myclient.database_names() 
    if doc.count() > 0:
        doc = collection.find()
        msg = list(doc)[2]
    else :
        msg = "查询失败"

    return render_template(
        'mongo.html',
        title='Mongo_query',
        year=datetime.now().year,
        message = msg,
        name = msg['name']
    )

@app.route("/add_mongo",methods=["GET","POST"])
def add_mongo():
    mongo_form = MongoForm()
    return render_template("mongo.html",**locals())
