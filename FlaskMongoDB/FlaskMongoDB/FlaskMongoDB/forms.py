from flask_wtf import FlaskForm # 定义表单
from wtforms import StringField, SubmitField
from wtforms.validators import DataRequired, Length,InputRequired

class MongoForm(FlaskForm):
    name = StringField(
        label="姓名",
        validators=[InputRequired(message = '姓名不可以为空 ')],
        render_kw={
            "class": "form-control",
            "placeholder": "姓名",
            "required" : False
        }
    )
    submit = SubmitField(
        label="提交",
        render_kw={
            "class": "btn btn-primary btn-block",
        },
    )
