--
-- PostgreSQL database dump
--

-- Dumped from database version 14.5
-- Dumped by pg_dump version 14.5

-- Started on 2023-06-08 11:33:47

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 852 (class 1247 OID 16772)
-- Name: gender; Type: TYPE; Schema: public; Owner: postgres
--

CREATE TYPE public.gender AS ENUM (
    'male',
    'female'
);


ALTER TYPE public.gender OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 209 (class 1259 OID 16584)
-- Name: courses; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.courses (
    id integer NOT NULL,
    name character varying(20) NOT NULL
);


ALTER TABLE public.courses OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 16594)
-- Name: departments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.departments (
    id integer NOT NULL,
    name character varying(20) NOT NULL
);


ALTER TABLE public.departments OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 24917)
-- Name: exceptions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.exceptions (
    id integer NOT NULL,
    message character varying
);


ALTER TABLE public.exceptions OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 24924)
-- Name: exceptions_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.exceptions ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.exceptions_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 213 (class 1259 OID 16604)
-- Name: graduates; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.graduates (
    id integer NOT NULL,
    name character varying(20) NOT NULL
);


ALTER TABLE public.graduates OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16614)
-- Name: lecturer_courses; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.lecturer_courses (
    lecturer_id integer NOT NULL,
    course_id integer NOT NULL
);


ALTER TABLE public.lecturer_courses OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 16589)
-- Name: lecturers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.lecturers (
    id integer NOT NULL,
    name character varying(20) NOT NULL,
    surname character varying(20) NOT NULL,
    email character varying(20) NOT NULL,
    is_deleted boolean DEFAULT false NOT NULL
);


ALTER TABLE public.lecturers OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 16609)
-- Name: student_course_grades; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.student_course_grades (
    student_id integer NOT NULL,
    course_id integer NOT NULL,
    vize integer DEFAULT 0,
    final integer DEFAULT 0,
    but integer DEFAULT 0
);


ALTER TABLE public.student_course_grades OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 16599)
-- Name: students; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.students (
    id integer NOT NULL,
    name character varying(20) NOT NULL,
    department_id integer NOT NULL,
    graduate_id integer NOT NULL,
    create_date timestamp(0) without time zone,
    update_date timestamp(0) without time zone,
    delete_date timestamp(0) without time zone,
    is_deleted boolean DEFAULT false NOT NULL,
    gender smallint NOT NULL
);


ALTER TABLE public.students OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 24925)
-- Name: user_infos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_infos (
    id integer NOT NULL,
    user_name character varying(20),
    email character varying(40),
    password character varying
);


ALTER TABLE public.user_infos OWNER TO postgres;

--
-- TOC entry 3205 (class 2606 OID 16588)
-- Name: courses courses_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.courses
    ADD CONSTRAINT courses_pkey PRIMARY KEY (id);


--
-- TOC entry 3209 (class 2606 OID 16598)
-- Name: departments department_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.departments
    ADD CONSTRAINT department_pkey PRIMARY KEY (id);


--
-- TOC entry 3226 (class 2606 OID 24923)
-- Name: exceptions exceptions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.exceptions
    ADD CONSTRAINT exceptions_pkey PRIMARY KEY (id);


--
-- TOC entry 3215 (class 2606 OID 16608)
-- Name: graduates graduate_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.graduates
    ADD CONSTRAINT graduate_pkey PRIMARY KEY (id);


--
-- TOC entry 3224 (class 2606 OID 16676)
-- Name: lecturer_courses lecturer_course_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lecturer_courses
    ADD CONSTRAINT lecturer_course_pkey PRIMARY KEY (lecturer_id, course_id);


--
-- TOC entry 3207 (class 2606 OID 16593)
-- Name: lecturers lecturer_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lecturers
    ADD CONSTRAINT lecturer_pkey PRIMARY KEY (id);


--
-- TOC entry 3219 (class 2606 OID 16613)
-- Name: student_course_grades student_grade_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_course_grades
    ADD CONSTRAINT student_grade_pkey PRIMARY KEY (student_id, course_id);


--
-- TOC entry 3213 (class 2606 OID 16603)
-- Name: students students_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_pkey PRIMARY KEY (id);


--
-- TOC entry 3228 (class 2606 OID 24931)
-- Name: user_infos user_infos_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_infos
    ADD CONSTRAINT user_infos_pkey PRIMARY KEY (id);


--
-- TOC entry 3220 (class 1259 OID 16658)
-- Name: fki_L; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_L" ON public.lecturer_courses USING btree (lecturer_id);


--
-- TOC entry 3216 (class 1259 OID 16682)
-- Name: fki_S; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_S" ON public.student_course_grades USING btree (student_id);


--
-- TOC entry 3217 (class 1259 OID 16688)
-- Name: fki_courseID; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_courseID" ON public.student_course_grades USING btree (course_id);


--
-- TOC entry 3221 (class 1259 OID 16670)
-- Name: fki_courses; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_courses ON public.lecturer_courses USING btree (course_id);


--
-- TOC entry 3210 (class 1259 OID 16629)
-- Name: fki_department; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_department ON public.students USING btree (department_id);


--
-- TOC entry 3211 (class 1259 OID 16641)
-- Name: fki_graduate; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_graduate ON public.students USING btree (graduate_id);


--
-- TOC entry 3222 (class 1259 OID 16664)
-- Name: fki_lecturer; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_lecturer ON public.lecturer_courses USING btree (lecturer_id);


--
-- TOC entry 3232 (class 2606 OID 16683)
-- Name: student_course_grades courseID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_course_grades
    ADD CONSTRAINT "courseID" FOREIGN KEY (course_id) REFERENCES public.courses(id) NOT VALID;


--
-- TOC entry 3234 (class 2606 OID 16665)
-- Name: lecturer_courses courses; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lecturer_courses
    ADD CONSTRAINT courses FOREIGN KEY (course_id) REFERENCES public.courses(id) NOT VALID;


--
-- TOC entry 3229 (class 2606 OID 16630)
-- Name: students department; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.students
    ADD CONSTRAINT department FOREIGN KEY (department_id) REFERENCES public.departments(id) NOT VALID;


--
-- TOC entry 3230 (class 2606 OID 16642)
-- Name: students graduate; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.students
    ADD CONSTRAINT graduate FOREIGN KEY (graduate_id) REFERENCES public.graduates(id) NOT VALID;


--
-- TOC entry 3233 (class 2606 OID 16659)
-- Name: lecturer_courses lecturer; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lecturer_courses
    ADD CONSTRAINT lecturer FOREIGN KEY (lecturer_id) REFERENCES public.lecturers(id) NOT VALID;


--
-- TOC entry 3231 (class 2606 OID 16677)
-- Name: student_course_grades studentID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_course_grades
    ADD CONSTRAINT "studentID" FOREIGN KEY (student_id) REFERENCES public.students(id) NOT VALID;


-- Completed on 2023-06-08 11:33:47

--
-- PostgreSQL database dump complete
--

