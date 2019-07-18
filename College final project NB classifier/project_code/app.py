import os
from flask import Flask, render_template, request, redirect, flash, url_for,send_file
from werkzeug.utils import secure_filename
import nb
import json

UPLOAD_FOLDER = 'C:/Users/liors/Desktop/project_code/website/usr_files'
ALLOWED_EXTENSIONS = set(['txt'])

app = Flask(__name__)

app.secret_key=os.urandom(24)

app.config['UPLOAD_FOLDER'] = UPLOAD_FOLDER

def allowed_file(filename):
    return '.' in filename and \
           filename.rsplit('.', 1)[1].lower() in ALLOWED_EXTENSIONS

@app.route("/")
def main():
    return render_template('index.html')

@app.route("/data",methods=['POST'])
def data():
    txt=request.form['txtarea']
    check=request.form['radio']
    if request.method == 'POST' and txt:
        ans=nb.driver(txt,vec,clas,check)
        return render_template('result.html',result=ans)
    else:
        return render_template('index.html')

@app.route("/upload")
def upload():
    return render_template('upload.html')

@app.route("/upload_file", methods = ['GET','POST'])
def upload_file():
    if request.method == 'POST':
        if 'file' not in request.files:
            flash('No file part')
            return redirect(request.url)
        file = request.files['file']
        if file.filename == '':
            flash('No selected file')
            return redirect(request.url)
        if file and allowed_file(file.filename):
            filename = secure_filename(file.filename)
            file.save(os.path.join(app.config['UPLOAD_FOLDER'], filename))
            ans=nb.fileTxtAnalysis(filename,vec,clas)
            return render_template('result.html',result=ans)
    return render_template('upload.html')


@app.route("/about")
def about():
    return render_template('about.html')

@app.route("/how")
def how():
    return render_template('how.html')

@app.route("/return_files")
def return_files():
    try:
        return send_file('C:/Users/liors/Desktop/project_code/website/fileToDownload/10FldCrsVal.xlsx', attachment_filename='10FldCrsVal.xlsx')
    except Exception as e:
        return str(e)

@app.route("/contact")
def contact():
    return render_template('contact.html')

@app.route("/report",methods=['POST'])
def report():
    report_text=request.json
    #print(report_text)
    with open('reports/data.json', 'a+') as outfile:
        json.dump(report_text, outfile)
    return redirect(request.url)


@app.errorhandler(404)
def page_not_found(e):
    return render_template('404.html'), 404

@app.errorhandler(405)
def Method_Not_Allowed(e):
    return render_template('index.html')

if __name__== "__main__" :
    vec,clas=nb.initAlgo()
    app.run(debug=True,host="0.0.0.0" , port=80)
