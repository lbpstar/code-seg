"""
The flask application package.
"""

from flask import Flask
app = Flask(__name__)
app.secret_key = "mongotest"
import FlaskMongoDB.views
