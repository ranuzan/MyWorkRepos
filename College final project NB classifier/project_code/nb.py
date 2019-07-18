#using for csv file and data frame
import pandas
#learning algorithm
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.naive_bayes import MultinomialNB
#python files
import os
import io
#scientific computing
import numpy
#using for texual analysis
import spacy

path = "C:/Users/liors/Desktop/project_code/website/"

def initDataframe():

    ndf = pandas.read_csv(path + "nonoffensive.csv")
    off = pandas.read_csv(path + "offensive.csv")

    finalData = pandas.DataFrame({'text':[],'class':[]})

    rows=[]
    index=[i for i in range(len(ndf.index)+len(off.index))]
    for i in range(len(off.index)):
        rows.append({'text':off['text'][i],'class':'offensive'})
    for i in range(len(ndf.index)):
        rows.append({'text':ndf['text'][i],'class':'nonoffensive'})
    finalData=finalData.append(pandas.DataFrame(rows,index=index),sort=True)

    return finalData

def initAlgo():
    #give learning algorithm the examples to learn from
    finalData=initDataframe()
    #print(finalData)

    #Convert a collection of text to a matrix of token counts
    #in simple it makes a vector of how many times a word appear in each sentence
    vectorizer = CountVectorizer()
    counts = vectorizer.fit_transform(finalData['text'].values)
    #print(counts[0].toarray())


    #The sklearn.naive_bayes module implements Naive Bayes algorithms. These are supervised learning methods
    #The multinomial Naive Bayes classifier is suitable for classification ((e.g., word counts for text classification)
    classifier = MultinomialNB()
    targets = finalData['class'].values
    #trains classifier
    classifier.fit(counts, targets) #Fit Naive Bayes classifier according to counts, targets
    return vectorizer,classifier

def makePrediction(data,vectorizer,classifier):

	#turns example into a words vector
	data_counts = vectorizer.transform(data)
	#predicts result
	predictions = classifier.predict(data_counts)
	#print(get_sentiment(data[0])+","+get_sentiment(data[1]))

	return predictions

def makePredicionAndSaveResult(data):

	#give learning algorithm the examples to learn from
	finalData=initDataframe()
    #print(finalData)


	vectorizer = CountVectorizer()
	counts = vectorizer.fit_transform(finalData['text'].values)


	classifier = MultinomialNB()
	targets = finalData['class'].values
	classifier.fit(counts, targets)

	data_counts = vectorizer.transform(data)
	predictions = classifier.predict(data_counts)

	return predictions

def testSet():
	ls = []
	res = []
	testSet = pandas.read_csv(path + "testSet.csv", error_bad_lines=False)
	#print(testSet.head())
	for index, row in testSet.iterrows():
		#print(row['text'])
		#print(index)
		ls.append(str(row['text']))
	res = makePredicionAndSaveResult(ls)

	for index, row in testSet.iterrows():
		testSet.at[index, 'actual'] = res[index]

	testSet.to_csv('testSet.csv',encoding='utf-8')

def breakByNewline(txt):
        return txt.splitlines()

def char66(txt):
    for index,line in enumerate(txt):
        if len(line)>=66:
            for i in range(1,len(line)+1):
                if i == 66 :
                    new = line[67:]
                    txt[index] = line[:66]
                    if new != "":
                        txt.insert(index+1,new)
                    break
        return txt

def fileTxtAnalysis(filename,vec,clas):
    dic = {}
    f = open("usr_files/"+filename, "r")
    txt=f.read()
    if txt == '':
        return
    nlp = spacy.load("en_core_web_sm")
    doc = nlp(txt)
    data = [sent.string.strip() for sent in doc.sents]

    ans=makePrediction(data,vec,clas)
    for i in range(len(ans)):
        dic[data[i]]=ans[i]

    f.close()
    return dic

def inLex(dic):
    f = open("Lexicon.txt", "r")
    txt=f.read()
    lex=[l for l in txt.replace(" ", "").splitlines()]
    for key,val in dic.items():
        if val == 'offensive':
            for index,word in enumerate(lex):
                if word in key:
                    break
                elif index == len(lex)-1:
                    dic[key]='nonoffensive'
    return dic
    #print(lex)
    #print(type(lex))


def driver(txt,vec,clas,check):
    dic = {}

    if check == 'ta':
        nlp = spacy.load("en_core_web_sm")
        doc = nlp(txt)
        data = [sent.string.strip() for sent in doc.sents]

    else :
        txt = breakByNewline(txt)
        data = txt

    ans=makePrediction(data,vec,clas)

    for i in range(len(ans)):
        dic[data[i]]=ans[i]

    dic=inLex(dic)
    return dic
