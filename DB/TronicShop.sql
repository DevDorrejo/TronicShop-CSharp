--
-- PostgreSQL database dump
--

-- Dumped from database version 17.4
-- Dumped by pg_dump version 17.4

-- Started on 2025-04-08 02:51:36 UTC

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 220 (class 1259 OID 16405)
-- Name: clientes; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.clientes (
    id integer NOT NULL,
    nombre character varying(100) NOT NULL,
    telefono character varying(20),
    correo character varying(100),
    direccion text,
    identificacion character varying(15),
    estado boolean DEFAULT true,
    fecha_creado timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


--
-- TOC entry 219 (class 1259 OID 16404)
-- Name: clientes_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.clientes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3494 (class 0 OID 0)
-- Dependencies: 219
-- Name: clientes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.clientes_id_seq OWNED BY public.clientes.id;


--
-- TOC entry 228 (class 1259 OID 16486)
-- Name: configuracion; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.configuracion (
    id integer NOT NULL,
    nombre_empresa character varying(100) NOT NULL,
    rnc character varying(20),
    direccion text,
    telefono character varying(20),
    correo character varying(100),
    impuesto numeric(5,2) DEFAULT 0.18,
    logo bytea,
    fecha_creado timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    fecha_actualizado timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


--
-- TOC entry 227 (class 1259 OID 16485)
-- Name: configuracion_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.configuracion_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3495 (class 0 OID 0)
-- Dependencies: 227
-- Name: configuracion_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.configuracion_id_seq OWNED BY public.configuracion.id;


--
-- TOC entry 226 (class 1259 OID 16467)
-- Name: detalle_ventas; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.detalle_ventas (
    id integer NOT NULL,
    id_venta integer NOT NULL,
    id_producto integer NOT NULL,
    cantidad integer DEFAULT 1 NOT NULL,
    precio_unitario numeric(10,2) NOT NULL,
    total_linea numeric(10,2) GENERATED ALWAYS AS (((cantidad)::numeric * precio_unitario)) STORED
);


--
-- TOC entry 225 (class 1259 OID 16466)
-- Name: detalle_ventas_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.detalle_ventas_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3496 (class 0 OID 0)
-- Dependencies: 225
-- Name: detalle_ventas_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.detalle_ventas_id_seq OWNED BY public.detalle_ventas.id;


--
-- TOC entry 230 (class 1259 OID 16502)
-- Name: productos; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.productos (
    id integer NOT NULL,
    codigo_barra character varying(50),
    nombre character varying(100) NOT NULL,
    descripcion text,
    categoria character varying(50),
    precio numeric(10,2) NOT NULL,
    stock integer DEFAULT 0 NOT NULL,
    estado boolean DEFAULT true,
    id_proveedor integer,
    fecha_creado timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    fecha_actualizado timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


--
-- TOC entry 229 (class 1259 OID 16501)
-- Name: productos_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.productos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3497 (class 0 OID 0)
-- Dependencies: 229
-- Name: productos_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.productos_id_seq OWNED BY public.productos.id;


--
-- TOC entry 222 (class 1259 OID 16416)
-- Name: proveedores; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.proveedores (
    id integer NOT NULL,
    "compañía" character varying(100) NOT NULL,
    nombre_contacto character varying(100),
    telefono character varying(20) NOT NULL,
    telefono2 character varying(20),
    whatsapp character varying(20),
    correo character varying(100),
    direccion text NOT NULL,
    rnc character varying(15),
    estado boolean DEFAULT true,
    fecha_creado timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    fecha_actualizado timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


--
-- TOC entry 221 (class 1259 OID 16415)
-- Name: proveedores_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.proveedores_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3498 (class 0 OID 0)
-- Dependencies: 221
-- Name: proveedores_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.proveedores_id_seq OWNED BY public.proveedores.id;


--
-- TOC entry 218 (class 1259 OID 16391)
-- Name: usuarios; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.usuarios (
    id integer NOT NULL,
    nombre character varying(100) NOT NULL,
    usuario character varying(50) NOT NULL,
    clave bytea NOT NULL,
    rol character varying(20) DEFAULT 'vendedor'::character varying NOT NULL,
    estado boolean DEFAULT true,
    fecha_creado timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


--
-- TOC entry 217 (class 1259 OID 16390)
-- Name: usuarios_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.usuarios_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3499 (class 0 OID 0)
-- Dependencies: 217
-- Name: usuarios_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.usuarios_id_seq OWNED BY public.usuarios.id;


--
-- TOC entry 224 (class 1259 OID 16447)
-- Name: ventas; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.ventas (
    id integer NOT NULL,
    id_cliente integer,
    id_usuario integer,
    total numeric(10,2) DEFAULT 0 NOT NULL,
    fecha timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    estado boolean DEFAULT true
);


--
-- TOC entry 223 (class 1259 OID 16446)
-- Name: ventas_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.ventas_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3500 (class 0 OID 0)
-- Dependencies: 223
-- Name: ventas_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.ventas_id_seq OWNED BY public.ventas.id;


--
-- TOC entry 3291 (class 2604 OID 16408)
-- Name: clientes id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.clientes ALTER COLUMN id SET DEFAULT nextval('public.clientes_id_seq'::regclass);


--
-- TOC entry 3305 (class 2604 OID 16489)
-- Name: configuracion id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.configuracion ALTER COLUMN id SET DEFAULT nextval('public.configuracion_id_seq'::regclass);


--
-- TOC entry 3302 (class 2604 OID 16470)
-- Name: detalle_ventas id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.detalle_ventas ALTER COLUMN id SET DEFAULT nextval('public.detalle_ventas_id_seq'::regclass);


--
-- TOC entry 3309 (class 2604 OID 16505)
-- Name: productos id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.productos ALTER COLUMN id SET DEFAULT nextval('public.productos_id_seq'::regclass);


--
-- TOC entry 3294 (class 2604 OID 16419)
-- Name: proveedores id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.proveedores ALTER COLUMN id SET DEFAULT nextval('public.proveedores_id_seq'::regclass);


--
-- TOC entry 3287 (class 2604 OID 16394)
-- Name: usuarios id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.usuarios ALTER COLUMN id SET DEFAULT nextval('public.usuarios_id_seq'::regclass);


--
-- TOC entry 3298 (class 2604 OID 16450)
-- Name: ventas id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.ventas ALTER COLUMN id SET DEFAULT nextval('public.ventas_id_seq'::regclass);


--
-- TOC entry 3319 (class 2606 OID 16414)
-- Name: clientes clientes_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.clientes
    ADD CONSTRAINT clientes_pkey PRIMARY KEY (id);


--
-- TOC entry 3329 (class 2606 OID 16496)
-- Name: configuracion configuracion_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.configuracion
    ADD CONSTRAINT configuracion_pkey PRIMARY KEY (id);


--
-- TOC entry 3325 (class 2606 OID 16474)
-- Name: detalle_ventas detalle_ventas_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.detalle_ventas
    ADD CONSTRAINT detalle_ventas_pkey PRIMARY KEY (id);


--
-- TOC entry 3332 (class 2606 OID 16515)
-- Name: productos productos_codigo_barra_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.productos
    ADD CONSTRAINT productos_codigo_barra_key UNIQUE (codigo_barra);


--
-- TOC entry 3334 (class 2606 OID 16513)
-- Name: productos productos_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.productos
    ADD CONSTRAINT productos_pkey PRIMARY KEY (id);


--
-- TOC entry 3321 (class 2606 OID 16427)
-- Name: proveedores proveedores_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.proveedores
    ADD CONSTRAINT proveedores_pkey PRIMARY KEY (id);


--
-- TOC entry 3315 (class 2606 OID 16401)
-- Name: usuarios usuarios_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.usuarios
    ADD CONSTRAINT usuarios_pkey PRIMARY KEY (id);


--
-- TOC entry 3317 (class 2606 OID 16403)
-- Name: usuarios usuarios_usuario_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.usuarios
    ADD CONSTRAINT usuarios_usuario_key UNIQUE (usuario);


--
-- TOC entry 3323 (class 2606 OID 16455)
-- Name: ventas ventas_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.ventas
    ADD CONSTRAINT ventas_pkey PRIMARY KEY (id);


--
-- TOC entry 3330 (class 1259 OID 16546)
-- Name: idx_codigo_barra; Type: INDEX; Schema: public; Owner: -
--

CREATE UNIQUE INDEX idx_codigo_barra ON public.productos USING btree (codigo_barra);


--
-- TOC entry 3326 (class 1259 OID 16548)
-- Name: idx_detalle_venta_producto; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX idx_detalle_venta_producto ON public.detalle_ventas USING btree (id_producto);


--
-- TOC entry 3327 (class 1259 OID 16547)
-- Name: idx_detalle_venta_venta; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX idx_detalle_venta_venta ON public.detalle_ventas USING btree (id_venta);


--
-- TOC entry 3339 (class 2606 OID 16541)
-- Name: detalle_ventas fk_detalle_producto; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.detalle_ventas
    ADD CONSTRAINT fk_detalle_producto FOREIGN KEY (id_producto) REFERENCES public.productos(id) ON DELETE SET NULL;


--
-- TOC entry 3340 (class 2606 OID 16475)
-- Name: detalle_ventas fk_detalle_venta; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.detalle_ventas
    ADD CONSTRAINT fk_detalle_venta FOREIGN KEY (id_venta) REFERENCES public.ventas(id) ON DELETE CASCADE;


--
-- TOC entry 3341 (class 2606 OID 16536)
-- Name: detalle_ventas fk_detalleventa_producto; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.detalle_ventas
    ADD CONSTRAINT fk_detalleventa_producto FOREIGN KEY (id_producto) REFERENCES public.productos(id) ON DELETE SET NULL;


--
-- TOC entry 3342 (class 2606 OID 16531)
-- Name: detalle_ventas fk_detalleventa_venta; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.detalle_ventas
    ADD CONSTRAINT fk_detalleventa_venta FOREIGN KEY (id_venta) REFERENCES public.ventas(id) ON DELETE CASCADE;


--
-- TOC entry 3343 (class 2606 OID 16516)
-- Name: productos fk_producto_proveedor; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.productos
    ADD CONSTRAINT fk_producto_proveedor FOREIGN KEY (id_proveedor) REFERENCES public.proveedores(id) ON DELETE SET NULL;


--
-- TOC entry 3335 (class 2606 OID 16456)
-- Name: ventas fk_venta_cliente; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.ventas
    ADD CONSTRAINT fk_venta_cliente FOREIGN KEY (id_cliente) REFERENCES public.clientes(id) ON DELETE SET NULL;


--
-- TOC entry 3336 (class 2606 OID 16461)
-- Name: ventas fk_venta_usuario; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.ventas
    ADD CONSTRAINT fk_venta_usuario FOREIGN KEY (id_usuario) REFERENCES public.usuarios(id) ON DELETE SET NULL;


--
-- TOC entry 3337 (class 2606 OID 16521)
-- Name: ventas fk_ventas_cliente; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.ventas
    ADD CONSTRAINT fk_ventas_cliente FOREIGN KEY (id_cliente) REFERENCES public.clientes(id) ON DELETE SET NULL;


--
-- TOC entry 3338 (class 2606 OID 16526)
-- Name: ventas fk_ventas_usuario; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.ventas
    ADD CONSTRAINT fk_ventas_usuario FOREIGN KEY (id_usuario) REFERENCES public.usuarios(id) ON DELETE SET NULL;


-- Completed on 2025-04-08 02:51:36 UTC

--
-- PostgreSQL database dump complete
--

