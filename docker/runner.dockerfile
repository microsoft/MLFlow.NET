FROM python:3.7.0

LABEL git "https://github.com/Microsoft/MLFlow.NET"

RUN mkdir /mlflow/

RUN pip install mlflow

COPY py.py ./

CMD python py.py