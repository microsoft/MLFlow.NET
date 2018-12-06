FROM python:3.7.0

LABEL git "https://github.com/Microsoft/MLFlow.NET"

RUN pip install mlflow

EXPOSE 5000

CMD mlflow server \
    --file-store /mlflow \
    --host 0.0.0.0