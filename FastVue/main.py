from fastapi import FastAPI
from routers import cost
from routers import qms

app = FastAPI(
    title="MyAPI",
    description="API描述",
    version="0.1.1",
    )
    
app.include_router(cost.router, prefix="/api")
app.include_router(qms.router, prefix="/api")

if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app='main:app', host="127.0.0.1", port=8000, reload=True, debug=True)





