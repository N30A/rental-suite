CREATE EXTENSION IF NOT EXISTS pg_trgm;

CREATE SEQUENCE IF NOT EXISTS customer_number_seq START 100001;
CREATE TABLE IF NOT EXISTS customers (
    id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    customer_number TEXT UNIQUE DEFAULT CONCAT('K', NEXTVAL('customer_number_seq')::TEXT),
    email TEXT,
    phone TEXT,
    address TEXT,
    postal_code TEXT,
    city TEXT,
    full_address TEXT GENERATED ALWAYS AS (
        COALESCE(address, '') || COALESCE(postal_code, '') || COALESCE(city, '')
    ) STORED,
    is_active BOOL DEFAULT TRUE,
    created_at TIMESTAMPTZ DEFAULT NOW(),
    updated_at TIMESTAMPTZ DEFAULT NOW()
);

CREATE INDEX IF NOT EXISTS idx_customers_customers_number ON customers(customer_number);
CREATE INDEX IF NOT EXISTS idx_customers_full_address_trgm ON customers USING GIN(full_address gin_trgm_ops);
CREATE INDEX IF NOT EXISTS idx_customers_is_active ON customers(is_active);

CREATE OR REPLACE FUNCTION fun_customers_updated_at()
RETURNS TRIGGER AS $$
BEGIN
    NEW.updated_at := NOW();
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE TRIGGER trg_customers_updated_at
BEFORE UPDATE ON customers
FOR EACH ROW
EXECUTE FUNCTION fun_customers_updated_at();

CREATE TABLE IF NOT EXISTS individuals (
    customer_id INT PRIMARY KEY REFERENCES customers(id) ON DELETE CASCADE,
    first_name TEXT NOT NULL,
    last_name TEXT NOT NULL,
    full_name TEXT GENERATED ALWAYS AS (first_name || ' ' || last_name) STORED
);

CREATE INDEX IF NOT EXISTS idx_individuals_full_name_trgm ON individuals USING GIN(full_name gin_trgm_ops);

CREATE TABLE IF NOT EXISTS companies (
    customer_id INT PRIMARY KEY REFERENCES customers(id) ON DELETE CASCADE,
    name TEXT NOT NULL,
    org_number TEXT
);

CREATE INDEX IF NOT EXISTS idx_companies_name_trgm ON companies USING GIN(name gin_trgm_ops);
CREATE INDEX IF NOT EXISTS idx_companies_org_number ON companies(org_number);
